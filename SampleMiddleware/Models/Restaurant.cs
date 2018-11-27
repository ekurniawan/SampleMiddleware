using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMiddleware.Models
{
    //menambahkan navigation property
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public int? JenisID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual Jenis Jenis { get; set; }
    }

   
}
