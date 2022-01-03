using Mapster.Models;
using Mapster.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace Mapster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService) { _productService = productService; }
        [HttpGet(template: "{id}")]
        public ProductViewModel GetById(int id)
        {
            var product = _productService.GetById(id);

            //Mapleme işlemini burada yapıyoruz.

            var productModel = product.Adapt<ProductViewModel>();

            return productModel;
        }
    }
}
