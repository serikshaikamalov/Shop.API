using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public int StatusId { get; set; }
                
        public int CategoryId { get; set; }

        // FK
        public int? ImageID { get; set; }

        // Dictionary
        public Image Image { get; set; }

    }
}