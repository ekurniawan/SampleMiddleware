using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleMiddleware.Services;

namespace SampleMiddleware.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantData _resto;
        public RestaurantController(IRestaurantData resto)
        {
            _resto = resto;
        }
        public IActionResult Index()
        {
            var models = _resto.GetAll();
            return View(models);
        }
    }
}