using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleMiddleware.Controllers
{
    //menambahkan routing
    [Route("Tentang")]
    public class AboutController : Controller
    {
        [Route("hello")]
        [Route("halo")]
        public IActionResult Index()
        {
            return Content("About Page");
        }
    }
}