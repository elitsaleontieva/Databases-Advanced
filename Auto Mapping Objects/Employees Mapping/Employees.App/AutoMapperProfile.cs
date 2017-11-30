using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App
{
    using AutoMapper;
    using Employees.Models;
    using Employees.DtoModels;

    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee,EmployeeDto>();
            CreateMap<EmployeeDto,Employee>();
        }
    }
}
