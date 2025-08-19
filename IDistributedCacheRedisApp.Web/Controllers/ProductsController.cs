using IDistributedCacheRedisApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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
            
            // redise string kayıt işlemi
            //_distributedCache.SetString("name","Latif54",cacheEntryOptions);
            //await _distributedCache.SetStringAsync("surname","Altay 54",cacheEntryOptions);

            // complex type kayıt işlemi 

            Product product = new Product();
            product.Id = 2;
            product.Name = "Kalem2";
            product.Price = 100;

            string jsonProduct = JsonConvert.SerializeObject(product);

            await _distributedCache.SetStringAsync("product:2", jsonProduct, cacheEntryOptions);

            return View();
        }



        public IActionResult Show() 
        {
            // rediste string okuma
            //var name = _distributedCache.GetString("name");
            //ViewBag.Name = name;

            // rediste complex type okuma
            var jsonProduct = _distributedCache.GetString("product:2");

            Product? p = JsonConvert.DeserializeObject<Product>(jsonProduct);

            ViewBag.Product = p;

            return View();
        }


        public IActionResult Remove()
        {
            // rediste string silme
            _distributedCache.Remove("name");
            
            
            return View();
        }

    }
}
