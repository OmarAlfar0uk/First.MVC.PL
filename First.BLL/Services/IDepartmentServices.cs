using First.BLL.DataTransferObjects;

namespace First.BLL.Services
{
    public interface IDepartmentServices
    {

        
        int AddDepartment(CreatedDebartmentDTO departmentDto);
        int CreateDepartment(CreatedDebartmentDTO departmentDto);
        bool DeleteDepartment(int Id);
        IEnumerable<DepartmentDTO> GatAllDepartments();
        DepartmentDetLsDTO? GetDepartmentById(int id);
        int UpdateDempartment(UpdatedDepartmentDTO departmentDto);
    }
}