using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ResponseCacheExample.Controllers
{
    [ApiController]

    [ResponseCache(CacheProfileName = "Default30")]
    public class TimeController : ControllerBase
    {
        [Route("api/[controller]")]
        [HttpGet]
        public ContentResult GetTime() => Content(
                          DateTime.Now.ToString("hh:mm:ss"));
    }
}
