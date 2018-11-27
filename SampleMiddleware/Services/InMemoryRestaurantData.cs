using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleMiddleware.Models;

namespace SampleMiddleware.Services
{//
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1,Name="Sate Klathak Pak Bari"},
                new Restaurant {Id=2,Name="Gudeg Yu Djum"},
                new Restaurant {Id=3,Name="Soto Kadipiro"}
            };
        }

        public void Delete(Restaurant resto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderByDescending(r=>r.Name);
        }

        public IEnumerable<Restaurant> GetAllWithJenis()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            var result = (from r in restaurants
                          where r.Id == id 
                          select r).SingleOrDefault();
            //var result = restaurants.Where(r => r.Id == id).SingleOrDefault();
            if (result == null)
                 throw new Exception("Data tidak ditemukan");
            
            return result;
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
