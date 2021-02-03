using System.Threading.Tasks;
using FinalBusiness.Concrete;
using FinalBusiness.Abstract;
using FinalDataAccess.Abstract;
using FinalDataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Text;
using FinalDataAccess.Concrete.EntityFreamwork;

//Solid
//open-closed => O
namespace ConsoleUI
{
    class Class1
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
