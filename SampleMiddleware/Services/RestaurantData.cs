using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SampleMiddleware.Models;
using System.Data.SqlClient;
using Dapper;

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
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Restaurant order by Name asc";
                var results = conn.Query<Restaurant>(strSql);
                return results;
                /*var lstResto = new List<Restaurant>();
                string strSql = @"select * from Restaurant order by Name asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstResto.Add(new Restaurant
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = dr["Name"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return lstResto;*/
            }
        }

        public Restaurant GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
