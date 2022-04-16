using Mapster.Entities;

namespace Mapster.Services
{
    public class ProductService : IProductService
    {
        public Product GetById(int id)
        {
            var product = new Product();

            product.Id = 1;
            product.Name = "Laptop";
            product.UnitPrice = 5000;

            return product;
        }
    }
}
