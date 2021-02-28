using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyErrorHandling.Filter;

namespace UdemyErrorHandling.Controllers
{

    [CustomHandleExceptionFilterAttribute(ErrorPage = "Hata2")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("veri tabanında bir hata meydana geldi");

            return View();
        }
    }
}