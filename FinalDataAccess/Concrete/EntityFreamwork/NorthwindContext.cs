using System;
using FinalEntities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FinalDataAccess.Concrete.EntityFreamwork
{
    //context : DB TABLOLALI İLE KODU BAĞLAMAK...
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\ProjectsV13;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Orders  { get; set; }

    }
}
