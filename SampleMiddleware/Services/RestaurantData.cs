using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SampleMiddleware.Models;
using System.Data.SqlClient;

namespace SampleMiddleware.Services
{
    public class RestaurantData : IRestaurantData
    {
        private IConfiguration _config;
        public RestaurantData(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
