using Day_05.Areas.HR.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Day_05.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=CompanyMVCTask;Trusted_Connection=True;Encrypt=false;");
        }
    }
}
