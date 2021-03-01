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
    public class Class1
    {
        static void Main(string[] args)
        {
            ProductGetAll();
            CategoryGetAll();
        }
        private static void CategoryGetAll()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            //foreach (var category in categoryManager.GetAll())
            //{
            //    Console.WriteLine(category.CategoryName);
            //}
        }
        private static void ProductGetAll()
        {
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //var result = productManager.GetProductDetail();
            //if (result.Success==true)
            //{
            //    foreach (var product in result.Data)
            //    {
            //        Console.WriteLine(product.ProductName + " " + product.CategoryName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
            
                
            
        }
    }
}
