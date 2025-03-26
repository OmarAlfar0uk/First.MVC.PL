using First.DAL.Data.Contexts;
using First.DAL.Repositories.Interfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.DAL.Repositories.Classes
{
    internal class EmployeeRepositioriy(AppDBContext dBContext) : GenaricRepository<Employee>(dBContext) , IEmployeeReposatore
    {

       
    }
}
