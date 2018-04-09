using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.DAL.Repositories;

namespace Shop.BLL
{
    using Shop.BLL.ViewModels;
    
    using Shop.DAL.Models;

    public class ProductBLL
    {
        ProductRepository _db;

        public ProductBLL()
        {
            _db = new ProductRepository();
        }


        /**
         * 
         */
        public List<Product> getList( int pageNumber, int limit = 3, int categoryId = 0 )
        {                    
            int offset = limit * (pageNumber - 1);
            return this._db.GetList(  offset, limit, categoryId);            
        }

        public Product getOne( int productId )
        {
            return this._db.GetOne(productId);
        }


        /**
         * CREATE
         */
        public void Create(Product product)
        {
            this._db.Create(product);
        }

        /**
         * GET TOTAL COUNT
         */
        public int getTotalCount( int categoryId = 0 )
        {
            return this._db.GetTotalCount( categoryId );
        }


        public void Edit( int productId, Product product )
        {
            this._db.Edit(productId, product);
        }


        public void Delete(int productId)
        {
            this._db.Delete(productId);
        }

    }
}