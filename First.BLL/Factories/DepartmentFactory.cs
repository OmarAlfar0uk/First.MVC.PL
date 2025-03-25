using First.BLL.DataTransferObjects;
using First.DAL.Models;
using First.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.BLL.Factories
{
    static class DepartmentFactory
    {
        public static Department ToEntity(this CreatedDebartmentDTO departmentDto)
        {
            return new Department()
            {
                Name = departmentDto.Name,
                Code  = departmentDto.Code,
                Description = departmentDto.Description,
                CreateOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDTO departmentDto) => new Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreateOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly()),
                Description = departmentDto.Description,

            };
        
    } 
}