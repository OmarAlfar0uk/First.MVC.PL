using First.DAL.Data.Configurations;
using First.DAL.Models.DepartmentModels;
using First.DAL.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace First.DAL.Data.Contexts
{ 
    public class AppDBContext(DbContextOptions<AppDBContext> options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; } 

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Connections");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        
    }
}