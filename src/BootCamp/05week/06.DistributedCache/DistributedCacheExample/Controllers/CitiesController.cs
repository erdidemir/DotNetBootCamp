using DistributedCacheExample.Models;
using DistributedCacheExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DistributedCacheExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;
        public CitiesController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        [HttpGet]
        public async Task<IEnumerable<City>> GetAsync(string countryId)
        {
            var cacheKey = countryId;
            IEnumerable<City> cities;
            string json;

            var citiesFromCache = await _distributedCache.GetAsync(countryId);
            if (citiesFromCache != null)
            {
                json = Encoding.UTF8.GetString(citiesFromCache);
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }
            else
            {
                cities = await Task.Run(() => CityService.GetCities(countryId));
                json = JsonConvert.SerializeObject(cities);
                citiesFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1)) // belirli bir süre erişilmemiş ise expire eder *****
                        .SetAbsoluteExpiration(DateTime.Now.AddMonths(1)); // belirli bir süre sonra expire eder.
                await _distributedCache.SetAsync(cacheKey, citiesFromCache, options);

            }
            return cities;
        }
    }
}
