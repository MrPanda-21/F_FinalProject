﻿using FinalDataAccess.Abstract;
using FinalEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalDataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                  new Product{ProductId= 1,ProductName="Glass", CategoryId = 1, UnitPrice= 50, UnitsInStock=120},
                  new Product{ProductId= 2,ProductName="PH-hone", CategoryId = 2, UnitPrice= 5000, UnitsInStock=5},
                  new Product{ProductId= 3,ProductName="KeyBoard", CategoryId = 3, UnitPrice= 320, UnitsInStock=100},
                  new Product{ProductId= 4,ProductName="Mouse", CategoryId = 4, UnitPrice= 750, UnitsInStock=7},
                  new Product{ProductId= 5,ProductName="Table", CategoryId = 5, UnitPrice= 50, UnitsInStock=50}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
           Product ProductToDelete= _products.SingleOrDefault(p=> p.ProductId== product.ProductId);
            _products.Remove(ProductToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
            return _products.Where(p => p.CategoryId == CategoryId).ToList();
        }

        public void Update(Product product)
        {
            Product ProductToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            ProductToUpdate.CategoryId = product.CategoryId;
            ProductToUpdate.ProductId = product.ProductId;
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.UnitPrice = product.UnitPrice;
            ProductToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
