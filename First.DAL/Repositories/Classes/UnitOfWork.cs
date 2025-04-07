using First.DAL.Data.Contexts;
using First.DAL.Repositories.Interfasecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.DAL.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDBContext dbContext;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        public UnitOfWork(AppDBContext _dbContext)
        {
            dbContext = _dbContext;
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(dbContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
        }

        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int SaveChanges() => dbContext.SaveChanges();
    }
}

        
