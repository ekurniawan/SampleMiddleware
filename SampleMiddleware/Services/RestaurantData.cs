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
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Restaurant where Id=@Id";
                var param = new { Id = id };
                var result = conn.QuerySingle<Restaurant>(strSql,param);
                return result;
            }
        }

        public void Insert(Restaurant resto)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Restaurant(Name) values(@Name)";
                var param = new { Name = resto.Name };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public void Update(Restaurant resto)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"update Restaurant set Name=@Name 
                                  where Id=@Id";
                var param = new { Name = resto.Name, Id = resto.Id };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public void Delete(Restaurant resto)
        {
            throw new NotImplementedException();
        }
    }
}
