namespace Employees.App
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using Employees.App.Commands.Contracts;
    using Employees.App.Commands;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;

    internal class CommandParser
    {
        public static ICommand Parse(IServiceProvider serviceProvider, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly
                .GetTypes()
                .Where(t => t.GetInterfaces()
                 .Contains(typeof(ICommand)));

            var commandType = commandTypes
                .SingleOrDefault(t=>t.Name==$"{commandName}Command");

            if (commandType==null)
            {
                throw new InvalidOperationException("Invalid command");
            }

            var constructor = commandType
                .GetConstructors()
                .FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(p => p.ParameterType);

            var constructorArgs = constructorParams
                .Select(p => serviceProvider.GetService(p))
                .ToArray();

            var command = (ICommand)constructor
                .Invoke(constructorArgs);


            return command;
            
        }
    }
}
