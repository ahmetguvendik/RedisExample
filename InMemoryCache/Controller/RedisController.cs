using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache.Controller;
 
[Route("api/[controller]")]
[ApiController]
public class RedisController   : ControllerBase
{
    private readonly IMemoryCache _cache;

    public RedisController(IMemoryCache cache)
    {
         _cache = cache;
    }

    [HttpGet("SetValue")]
    public IActionResult SetValue(string name)
    {
        _cache.Set<string>("name", name , TimeSpan.FromSeconds(15));   
        return Ok("Cache set");
    }
    
    [HttpGet("GetValue")]
    public string GetValue()
    {
     //  var value =  _cache.Get<string>("name");
       if (_cache.TryGetValue("name", out var name))
       {
           return (string)name;
       }
       return "";
    }

}