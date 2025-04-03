using First.BLL.DataTransferObjects.DepartmentDataTransferObject;
using First.BLL.Factories;
using First.DAL.Repositories.Interfasecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.BLL.Services.DepartmentServices
{
    public class DepartmentServices(IDepartmentRepository _departmintRepositoriy) : IDepartmentServices

    {

        public IEnumerable<DepartmentDTO> GatAllDepartments()

        {
            var departments = _departmintRepositoriy.GetAll();
            var departmentsToReturn = departments.Select(D => new DepartmentDTO()
            {
                DepId = D.Id,
                Code = D.Code,
                Name = D.Name,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime(D.CreateOn)
            });
            return departmentsToReturn;
        }

        public DepartmentDetLsDTO? GetDepartmentById(int id)
        {
            var department = _departmintRepositoriy.GetById(id);
            return department is null ? null : new DepartmentDetLsDTO()
            {
                Id = department.Id,
                Name = department.Name,
                CreateOn = DateOnly.FromDateTime(department.CreateOn)
            };


        }

        public int AddDepartment(CreatedDebartmentDTO departmentDto)
        {
            var debartment = departmentDto.ToEntity();
            return _departmintRepositoriy.Add(debartment);
        }

        public int UpdateDempartment(UpdatedDepartmentDTO departmentDto)
        {
            return _departmintRepositoriy.Update(departmentDto.ToEntity());
        }

        public bool DeleteDepartment(int Id)
        {
            var Department = _departmintRepositoriy.GetById(Id);
            if (Department is null) return false;
            else
            {
                int Result = _departmintRepositoriy.Delete(Department);
                return Result > 0 ? true : false;
            }

        }
    }
}
