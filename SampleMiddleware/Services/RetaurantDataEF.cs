using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleMiddleware.Data;
using SampleMiddleware.Models;

namespace SampleMiddleware.Services
{
    public class RestaurantDataEF : IRestaurantData
    {
        private RestaurantDbContext _db;
        public RestaurantDataEF(RestaurantDbContext db)
        {
            _db = db;
        }
        public void Delete(Restaurant resto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //var results = _db.Restaurant.OrderBy(r => r.Name);
            var results = from r in _db.Restaurant
                          orderby r.Name ascending
                          select r;

            return results;
        }

        public IEnumerable<Restaurant> GetAllWithJenis()
        {
            var results = from r in _db.Restaurant.Include("Jenis")
                          orderby r.Name descending
                          select r;
            return results;
        }

        //public IEnumerable<Restaurant> GetAllWithJenis()
        //{
        //    var 
        //}

        public Restaurant GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Restaurant resto)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant resto)
        {
            throw new NotImplementedException();
        }
    }
}
