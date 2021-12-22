using BindingSourceParameters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BindingSourceParameters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet("get/{authorId}")]
        public IActionResult Get(Author author)
        {
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([ModelBinder(Name = "id")] Author author)
        {
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
