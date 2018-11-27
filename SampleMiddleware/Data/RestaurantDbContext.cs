using Microsoft.EntityFrameworkCore;
using SampleMiddleware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMiddleware.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Jenis> Jenis { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
    }
}
