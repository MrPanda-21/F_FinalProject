using FinalBusiness.Abstract;
using FinalBusiness.Concrete;
using FinalDataAccess.Concrete.EntityFreamwork;
using FinalEntities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    { 

        [HttpGet]
        public List<Product> Get()
        {
            IProductService productService =
                new ProductManager(new EfProductDal());
            var result = productService.GetAll();
            return result.Data;
            //return new List<Product>
            //{
            //    new Product{CategoryId = 1, ProductName = "Apple"},
            //    new Product{CategoryId = 2, ProductName = "Peer"},
            //};
        }
    }
}
