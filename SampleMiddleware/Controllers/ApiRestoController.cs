using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleMiddleware.Models;
using SampleMiddleware.Services;

namespace SampleMiddleware.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiRestoController : ControllerBase
    {
        private IRestaurantData _resto;
        public ApiRestoController(IRestaurantData resto)
        {
            _resto = resto;
        }

        // GET: api/ApiResto
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _resto.GetAllWithJenis();
        }

        // GET: api/ApiResto/5
        [HttpGet("{id}", Name = "Get")]
        public Restaurant Get(int id)
        {
            return _resto.GetById(id);
        }

        // POST: api/ApiResto
        [HttpPost]
        public IActionResult Post([FromBody] Restaurant resto)
        {
            try
            {
                _resto.Insert(resto);
                return Ok("Data berhasil ditambah");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ApiResto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
