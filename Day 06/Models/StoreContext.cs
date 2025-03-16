using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Day_06.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=StoreMVCTask;Trusted_Connection=True;Encrypt=false;");
        //}
    }
}
