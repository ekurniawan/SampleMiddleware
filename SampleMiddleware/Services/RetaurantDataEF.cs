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
            var results = (from r in _db.Restaurant
                          orderby r.Name ascending
                          select r).AsNoTracking();

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
            var result = (from r in _db.Restaurant
                          where r.Id == id
                          select r).SingleOrDefault();
            if (result == null)
                throw new Exception("Data tidak ditemukan");
            return result;
        }

        public void Insert(Restaurant resto)
        {
            try
            {
                _db.Restaurant.Add(resto);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Restaurant resto)
        {
            try
            {
                var data = GetById(resto.Id);
                data.Name = resto.Name;
                data.JenisID = resto.JenisID;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
