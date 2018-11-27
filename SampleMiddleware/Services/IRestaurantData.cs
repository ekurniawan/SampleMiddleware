using SampleMiddleware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMiddleware.Services
{
    //interface
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
        IEnumerable<Restaurant> GetAllWithJenis();
        void Insert(Restaurant resto);
        void Update(Restaurant resto);
        void Delete(Restaurant resto);
    }
}
