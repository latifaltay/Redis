using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.Web.Services;
using StackExchange.Redis;

namespace RedisExchangeAPI.Web.Controllers
{
    public class StringTypeController : Controller
    {
        private readonly RedisService _redisService;
        private readonly IDatabase db;
        public StringTypeController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(0);
        }

        public IActionResult Index()
        {

            db.StringSet("name", "Latif Altay 54");
            db.StringSet("Ziyaretçi", 100);

            return View();
        }


        public IActionResult Show()
        {
            var value = db.StringGet("name");
            db.StringIncrement("Ziyaretçi", 1);
            if (value.HasValue) 
            {
                ViewBag.value = value.ToString();
            }

            return View();
        }
    }
}
