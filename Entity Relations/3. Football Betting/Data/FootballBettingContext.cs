
namespace P03_FootballBetting.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            :base(options)
        {

        }



        public DbSet<User> Users  { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Bet> Bets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity
                .Property(e => e.Name)
                .IsRequired(true)
                .IsUnicode()
                .HasMaxLength(80);


                entity
                .Property(e => e.Initials)
                .IsRequired()
                .HasColumnType("NCHAR(3)");

                entity
                .Property(e => e.LogoUrl)
                .IsUnicode(false);
                

                entity
                .HasOne(pc => pc.PrimaryKitColor)
                .WithMany(t => t.PrimaryKitTeams)
                .HasForeignKey(pc => pc.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(pc => pc.SecondaryKitColor)
                .WithMany(t => t.SecondaryKitTeams)
                .HasForeignKey(pc => pc.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(tn => tn.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(tn => tn.TownId);

               
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity
                .HasKey(e => e.ColorId);
                
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity
                .HasKey(e => e.TownId);

                entity
                .HasOne(e => e.Country)
                .WithMany(t => t.Towns)
                .HasForeignKey(f => f.CountryId);
                

            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity
                .HasKey(e => e.CountryId);

               
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity
                .HasKey(e => e.PlayerId);

                entity
                .HasOne(t => t.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(f => f.PlayerId);

                entity
                .HasOne(p => p.Position)
                .WithMany(pl => pl.Players)
                .HasForeignKey(f => f.PositionId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity
                .HasKey(e => e.PositionId);
                
              

            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity
                .HasKey(e => new
                {
                    e.PlayerId,e.GameId
                });

                entity
                .HasOne(g => g.Game)
                .WithMany(gs => gs.PlayerStatistics)
                .HasForeignKey(g => g.GameId);

                entity
                .HasOne(p => p.Player)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(p => p.PlayerId);

            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                .HasKey(e => e.GameId);

                entity
                .HasOne(e => e.HomeTeam)
                .WithMany(c => c.HomeGames)
                .HasForeignKey(z => z.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict); 

                entity
                .HasOne(e => e.AwayTeam)
                .WithMany(c => c.AwayGames)
                .HasForeignKey(z => z.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict); ;

               


            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity
                .HasKey(e => e.BetId);

                entity
                .HasOne(e => e.Game)
                .WithMany(b => b.Bets)
                .HasForeignKey(f=>f.GameId);

                entity
                .HasOne(p => p.User)
                .WithMany(b => b.Bets)
                .HasForeignKey(u => u.UserId);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                .HasKey(e => e.UserId);

            });

        }

       
    }
}
