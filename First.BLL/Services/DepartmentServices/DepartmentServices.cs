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
    public class DepartmentServices(IUnitOfWork _unitOfWork) : IDepartmentServices

    {

        public IEnumerable<DepartmentDTO> GatAllDepartments()

        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentsToReturn = departments.Select(D => new DepartmentDTO()
            {
                DepId = D.Id,
                Code = D.Code,
                Name = D.Name,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime(D.CreateOn.GetValueOrDefault())
            });
            return departmentsToReturn;
        }

        public DepartmentDetLsDTO? GetDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            return department is null ? null : new DepartmentDetLsDTO()
            {
                Id = department.Id,
                Name = department.Name,
                CreateOn = DateOnly.FromDateTime(department.CreateOn ?? DateTime.MinValue)
            };


        }

        public int AddDepartment(CreatedDebartmentDTO departmentDto)
        {
            var debartment = departmentDto.ToEntity();
             _unitOfWork.DepartmentRepository.Add(debartment);
            return _unitOfWork.SaveChanges();
        }

        public int UpdateDempartment(UpdatedDepartmentDTO departmentDto)
        {
            _unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
             return _unitOfWork.SaveChanges();

        }

        public bool DeleteDepartment(int Id)
        {
            var Department = _unitOfWork.DepartmentRepository.GetById(Id);
            if (Department is null) return false;
            else
            {
                _unitOfWork.DepartmentRepository.Delete(Department);
                int Result =  _unitOfWork.SaveChanges();

                return Result > 0 ? true : false;
            }

        }
    }
}
