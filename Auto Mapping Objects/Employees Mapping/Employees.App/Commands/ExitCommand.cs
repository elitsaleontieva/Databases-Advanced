namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;

    class ExitCommand : ICommand
    {
        public string Execute(params string[] args)
        {
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
