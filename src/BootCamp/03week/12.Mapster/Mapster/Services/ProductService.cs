using Mapster.Entities;

namespace Mapster.Services
{
    public class ProductService : IProductService
    {
        public Product GetById(int id)
        {
            var product = new Product();

            product.ProductId = 1;
            product.ProductName = "Laptop";
            product.UnitPrice = 5000;

            return product;
        }
    }
}
