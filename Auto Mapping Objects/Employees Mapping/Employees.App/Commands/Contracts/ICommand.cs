using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands.Contracts
{
    internal interface ICommand
    {
        string Execute(params string [] args);
    }
}
