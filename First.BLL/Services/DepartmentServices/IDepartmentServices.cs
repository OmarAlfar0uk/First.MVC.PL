using First.BLL.DataTransferObjects.DepartmentDataTransferObject;

namespace First.BLL.Services.DepartmentServices
{
    public interface IDepartmentServices
    {
        int AddDepartment(CreatedDebartmentDTO departmentDto);
        bool DeleteDepartment(int Id);
        IEnumerable<DepartmentDTO> GatAllDepartments();
        DepartmentDetLsDTO? GetDepartmentById(int id);
        int UpdateDempartment(UpdatedDepartmentDTO departmentDto);
    }
}