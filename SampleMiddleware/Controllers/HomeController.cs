using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleMiddleware.Models;

namespace SampleMiddleware.Controllers
{
    public class HomeController : Controller
    {
        //
        public IActionResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Sate Klathak Pak Bari" };
            return View(model);
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