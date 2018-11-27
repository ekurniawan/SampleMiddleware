using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMiddleware.Models
{
    public class Jenis
    {
        public Jenis()
        {
            this.Restaurants = new List<Restaurant>();
        }

        public int JenisID { get; set; }
        public string NamaJenis { get; set; }

        public virtual List<Restaurant> Restaurants { get; set; }
    }
}
