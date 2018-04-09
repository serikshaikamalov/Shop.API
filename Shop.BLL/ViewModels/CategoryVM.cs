﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.BLL.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ParentId { get; set; }

        public bool StatusId { get; set; }

        public List<CategoryVM> Children { get; set; }
    }
}