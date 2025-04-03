using First.DAL.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.DAL.Repositories.Interfasecs
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
