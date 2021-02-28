using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UdemyErrorHandling.Filter;
using UdemyErrorHandling.Models;

namespace UdemyErrorHandling.Controllers
{
    [CustomHandleExceptionFilterAttribute(ErrorPage = "Hata1")]
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
           
            //throw new Exception("Veri tabanına bağlanırken bir hata meydana geldi");

            //int value1 = 5;
            //int value2 = 0;
            //int result = value1 / value2;
            return View();
        }
        
        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }

        [AllowAnonymous]//sadece üye olanlar görmesin, hatayı herkes görsün 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.path = exception.Path;
            ViewBag.message = exception.Error.Message;

            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return View();
        }

        public IActionResult Hata1()
        {
            return View();
        }

        public IActionResult Hata2()
        {
            return View();
        }
    }
}
