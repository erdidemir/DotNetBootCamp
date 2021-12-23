using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Routing.Entities;
using System.Collections.Generic;

namespace Routing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        [ActionName("Thumbnail")]
        public IActionResult GetThumbnailImage(int id)
        {
            return Ok();
        }

        [HttpPost]
        [ActionName("Thumbnail")]
        public void AddThumbnailImage(int id)
        {

        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return new List<Product> { new Product { Id = 1, Name = "Kullanıcı eşyaları" } };
        }

        [HttpGet("/products/{id}", Name = "Products_List")]
        public ActionResult<Product> GetProductId(int id)
        {
            return new Product { Id = 1, Name = "Laptop" };
        }

        [HttpGet("users/{userId}/products")]
        public ActionResult<IEnumerable<Product>> GetProductId(string userId)
        {
            return new List<Product> { new Product { Id = 1, Name = "Kullanıcı eşyaları" }};
        }

        // Not an action method.
        [NonAction]
        public string GetPrivateData()
        {
            return "abc";
        }
    }
}
