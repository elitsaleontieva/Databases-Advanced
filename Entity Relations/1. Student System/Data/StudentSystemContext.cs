


namespace P01_StudentSystem.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

   public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {

        }



        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }





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

            modelBuilder.Entity<Homework>(entity =>
            {
                entity
                .HasKey(e => e.HomeworkId);

                entity
                .Property(e => e.Content)
                .HasColumnType("VARCHAR(MAX)")
                .IsUnicode(false);

                entity
                .HasOne(e => e.Student)
                .WithMany(hs => hs.HomeworkSubmissions)
                .HasForeignKey(f=>f.StudentId);

                entity
                .HasOne(c => c.Course)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(f=>f.CourseId);


            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity
                .HasKey(e => e.CourseId);

                entity
                .Property(e => e.Name)
                .IsUnicode(true)
                .HasMaxLength(80);

                entity
                .Property(e => e.Description)
                .IsUnicode()
                .IsRequired(false);


            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity
                .HasKey(e => e.ResourceId);

                entity
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

                entity
                .Property(e => e.Url)
               .IsUnicode(false);

                entity
                .HasOne(e => e.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(f=>f.CourseId);


            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity
                .HasKey(e => e.StudentId);

                entity
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(true);

                entity
                .Property(e=>e.PhoneNumber)
                .HasColumnType("CHAR(10)")
                .IsUnicode(false)
                .IsRequired(false);

                entity
                .Property(e => e.Birthday)
                .IsRequired(false);
                

            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity
                .HasKey(e => new
                {
                    e.CourseId,e.StudentId
                });

                entity
                .HasOne(e => e.Student)
                .WithMany(c => c.CourseEnrollments)
                .HasForeignKey(f=>f.StudentId);

                entity
                .HasOne(e => e.Course)
                .WithMany(se => se.StudentsEnrolled)
                .HasForeignKey(f=>f.CourseId);
                

            });



        }
    }
}
