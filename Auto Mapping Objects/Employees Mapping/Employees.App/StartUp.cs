namespace Employees.App
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Employees.Data;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Employees.Models;
    using Employees.Services;
    using AutoMapper;

    class StartUp
    {
        static void Main()
        {
            var serviceProvider = ConfigureServices();
            var engine = new Engine(serviceProvider);
            engine.Run();
        }

        static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<EmployeeService>();

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

            var serviceProvider=serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
