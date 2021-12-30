using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnTypesExample.Entities;
using ReturnTypesExample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ReturnTypesExample.Controllers
{
    /// <summary>
    /// The Web API action method can have following return types.
    /// 1.	Void 
    /// 2.	Primitive type or Complex type 
    /// 3.	IActionResult
    /// </summary>
    /// 

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //1.	Void 
        [HttpDelete]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }


        //2.	Primitive type
        [HttpGet("Count")]
        public int Count()
        {
            return _productService.Count();
        }

        //2.	Complex type 
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productService.GetAll();
        }

        //2.	Complex type 
        [HttpGet("First")]
        public Product FirstProduct()
        {
            return _productService.GetAll().OrderBy(p => p.Id).FirstOrDefault();
        }

        //3. IActionResult
        [HttpGet("{id}")]
        public IActionResult GetEntityById(int id)
        {
            var product =  _productService.GetAll().Where(p => p.Id == id).FirstOrDefault();

            if (product == null)
                return NotFound();

            return Ok(product); 
        }

    }
}
