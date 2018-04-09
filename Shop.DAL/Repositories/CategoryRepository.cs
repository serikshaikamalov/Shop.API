using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Shop.DAL.Models;

namespace Shop.DAL.Repositories
{
    public class CategoryRepository: ShopContext
    {
        private ShopContext db;
        
        public CategoryRepository()
        {
            this.db = new ShopContext();
        }

        /**
         * @return 
         */
        public List<Category> GetList()
        {            
            return this.db.Categories.ToList();
        }

    
    }
}