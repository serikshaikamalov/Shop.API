using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ParentId { get; set; }

        public bool StatusId { get; set; }
    }
}