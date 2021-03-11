using System;
using Core.Entities.Concrete;
using FinalEntities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FinalDataAccess.Concrete.EntityFreamwork
{
    //context : DB TABLOLALI İLE KODU BAĞLAMAK...
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\ProjectsV13;Database=master;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Order> Orders  { get; set; }

    }
}
