using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistributedCacheExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly IDistributedCache _distributedCache;

        public TestController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            await _distributedCache.SetStringAsync("TestKey", "TestValue123");
            return _distributedCache.GetString("TestKey");
        }

        [HttpGet]
        public async Task<string> Time()
        {
            var cacheKey = "Time";
            var existingTime = _distributedCache.GetString(cacheKey);
            if (string.IsNullOrEmpty(existingTime))
            {
                existingTime = DateTime.UtcNow.ToString();
                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(5));
                option.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);
                string name = await _distributedCache.GetStringAsync("Name");
                await _distributedCache.SetStringAsync(cacheKey, $"{name}: {existingTime}", option);
            }
            return await _distributedCache.GetStringAsync(cacheKey);
        }
    }
}
