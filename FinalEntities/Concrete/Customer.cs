using System;
using Core.Entities;


namespace FinalEntities.Concrete
{
    public class Customer:IEntity
    {
        public Customer()
        {
        }

        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string  CompanyName { get; set; }
        public string City { get; set; }
    }
}
