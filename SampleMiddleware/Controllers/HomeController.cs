using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleMiddleware.Controllers
{
    public class HomeController : Controller
    {
        //
        public IActionResult Index()
        {
            return Content("Hello from Home Controller");
        }

        public IActionResult ReadArticle(string article)
        {
            return Content($"Anda mengakses artikel: {article}");
        }

        public IActionResult About()
        {
            return Content("Hello from About");
        }
    }
}