namespace Employees.App
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    internal class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        internal void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();
                string [] commandParts = input.Split(' ');
                var commandName = commandParts[0];
                var commandArgs = commandParts.Skip(1).ToArray();

                var command = CommandParser.Parse(serviceProvider, commandName);

                var result = command.Execute(commandArgs);

                Console.WriteLine(result);


            }
        }
    }
}
