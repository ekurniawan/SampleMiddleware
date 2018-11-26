using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleMiddleware.Models;

namespace SampleMiddleware.Services
{
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
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r=>r.Name);
        }


    }
}
