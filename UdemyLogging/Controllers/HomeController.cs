using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UdemyLogging.Models;

namespace UdemyLogging.Controllers
{
    public class HomeController : Controller
    {
        //1.yol
        //private readonly ILogger<HomeController> logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    this.logger = logger;
        //}

        private readonly ILoggerFactory loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            var logger = loggerFactory.CreateLogger("HomeSınıfı");

            logger.LogTrace("Index sayfasına girildi.");
            logger.LogDebug("Index sayfasına girildi.");
            logger.LogInformation("Index sayfasına girildi.");
            logger.LogWarning("Index sayfasına girildi.");
            logger.LogError("Index sayfasına girildi.");
            logger.LogCritical("Index sayfasına girildi.");


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
