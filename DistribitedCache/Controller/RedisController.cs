using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace DistribitedCache.Controller;

    [Route("api/[controller]")]
    [ApiController]
    public class RedisController   : ControllerBase
    {
        private readonly IDistributedCache _cache;

        public RedisController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpGet("SetValue")]
        public async Task<IActionResult> SetValue(string name,string surname)
        {
            await _cache.SetStringAsync("Name", name, options: new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(1)
            });
            
            await _cache.SetAsync("Surname", Encoding.UTF8.GetBytes(surname));
            return Ok("Cache set");
        }
    
        [HttpGet("GetValue")]
        public async Task<string> GetValue()
        {
           var values = await _cache.GetStringAsync("Name");
           var surname = await _cache.GetAsync("Surname");
           var surnameValue = Encoding.UTF8.GetString(surname); 
           return new
           {
               Name = values,
               Surname = surnameValue
           }.ToString();
        }

    }
