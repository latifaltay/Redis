using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace IDistributedCacheRedisApp.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IDistributedCache _distributedCache;

        public ProductsController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<IActionResult> Index()
        {
            DistributedCacheEntryOptions cacheEntryOptions = new();
            
            cacheEntryOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(1);
            

            _distributedCache.SetString("name","Latif54",cacheEntryOptions);
            await _distributedCache.SetStringAsync("surname","Altay 54",cacheEntryOptions);

            return View();
        }



        public IActionResult Show() 
        {
            var name = _distributedCache.GetString("name");
            ViewBag.Name = name;
            return View();
        }


        public IActionResult Remove()
        {
            _distributedCache.Remove("name");
            return View();
        }

    }
}
