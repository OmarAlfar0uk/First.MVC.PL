 using First.DAL.Data.Contexts;
using First.DAL.Repositories.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.DAL.Repositories.Classes
{
    public class DepartmintRepositoriy(AppDBContext dbcontext) : GenaricRepository<Department>(dbcontext), IDepartmintRepositoriy
    {



    }
}