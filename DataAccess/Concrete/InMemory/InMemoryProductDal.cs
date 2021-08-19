using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Orale, Sql Server, Postgres, MongoDB
            _products = new List<Product> 
            { 
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product{ProductId = 2, CategoryId = 1, ProductName = "kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product{ProductId = 3, CategoryId = 2, ProductName = "telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product{ProductId = 4, CategoryId = 2, ProductName = "klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product{ProductId = 5, CategoryId = 2, ProductName = "fare", UnitPrice = 85, UnitsInStock = 1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ- Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p => product.ProductId == p.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetByAllCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => product.ProductId == p.ProductId);
            productToUpdate.ProductName    = product.ProductName;
            productToUpdate.CategoryId     = product.CategoryId;
            productToUpdate.UnitPrice      = product.UnitPrice;
            productToUpdate.UnitsInStock   = product.UnitsInStock;
        }
    }
}
