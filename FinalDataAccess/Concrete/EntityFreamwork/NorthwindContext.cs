using System;
using Microsoft.EntityFrameworkCore;

namespace FinalDataAccess.Concrete.EntityFreamwork
{
    //context : DB TABLOLALI İLE KODU BAĞLAMAK...
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }


    }
}
