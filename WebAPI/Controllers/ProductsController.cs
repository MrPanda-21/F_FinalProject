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
        //Loosely coupled - Gevşek bağımlılık
        //Naming Convention
        //IoC Container --  Inversion of Controler
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            ////Dependency Chain
            //IProductService productService =
            //    new ProductManager(new EfProductDal());
            //Swagger
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
            //return new List<Product>
            //{
            //    new Product{CategoryId = 1, ProductName = "Apple"},
            //    new Product{CategoryId = 2, ProductName = "Peer"},
            //};
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("Add")]//alias verilmiş oldu...
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
