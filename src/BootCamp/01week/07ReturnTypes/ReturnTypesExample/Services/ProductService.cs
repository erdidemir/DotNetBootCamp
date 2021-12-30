using ReturnTypesExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReturnTypesExample.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _productList = new List<Product>();

        public ProductService()
        {
            _productList = SeedProduct();
        }

        private List<Product> SeedProduct()
        {
            return new List<Product> {
                new Product(1, "Laptop"),
                new Product(2, "Yazıcı"),
                new Product(3, "Mouse"),
                new Product(4, "Klavye")
                };
        }
        public int Count()
        {
            return _productList.Count();
        }

        public void Delete(int Id)
        {
            Console.WriteLine("{0} id'li ürün başarılı bir şekilde silindi.");
        }

        public IEnumerable<Product> GetAll()
        {
            return _productList;
        }

        public Product GetProductById(int id)
        {
            return _productList.FirstOrDefault(p => p.Id == id);
        }

       
    }
}
