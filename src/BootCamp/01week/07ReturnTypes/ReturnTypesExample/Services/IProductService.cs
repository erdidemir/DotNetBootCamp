using ReturnTypesExample.Entities;
using System.Collections.Generic;

namespace ReturnTypesExample.Services
{
    public interface IProductService
    {
        void Delete(int Id);

        int Count();

        IEnumerable<Product> GetAll();
        Product GetProductById(int id);
    }
}
