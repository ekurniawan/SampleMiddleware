using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleMiddleware.Models;
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
            var models = _resto.GetAllWithJenis();
            return View(models);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurant resto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _resto.Insert(resto);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Error"] = 
                    $"<span class='alert alert-danger'>{ex.Message}</span>";
                return View(resto);
            }
        }

        public IActionResult Details(int id)
        {
            var model = _resto.GetById(id);
            return View(model);
        }
    }
}