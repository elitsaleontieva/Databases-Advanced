namespace Employees.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Employees.Models;
    using Employees.Data;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            
        }

    }
}
