using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMangment.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public double Price { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
