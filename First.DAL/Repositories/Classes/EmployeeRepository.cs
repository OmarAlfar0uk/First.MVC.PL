using First.DAL.Data.Contexts;
using First.DAL.Models.EmployeeModels;
using First.DAL.Repositories.Interfasecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.DAL.Repositories.Classes
{
    public class EmployeeRepository(AppDBContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
    {

    }
}
