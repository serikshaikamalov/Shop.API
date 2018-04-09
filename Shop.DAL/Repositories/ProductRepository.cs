using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Shop.DAL.Models;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : ShopContext
    {
        private ShopContext db;

        public ProductRepository()
        {
            this.db = new ShopContext();
        }

        /**
         * @return List<Product>
         */
        public List<Product> GetList( int offSet = 0, 
                                      int limit = 3, 
                                      int categoryId = 0 )
        {
            var query = this.db.Products
                .Where(x => x.StatusId == 1);             

            // FILTER
            if ( categoryId != 0 )
            {
                var categoryIds = new List<int>();

                categoryIds.Add(categoryId);

                // Find subcategories
                var subcategories = this.db.Categories.Where(x => x.ParentId == categoryId).ToList(); 
                if( subcategories.Count > 0)
                {
                    foreach (var subcategory in subcategories)
                    {
                        // Find Sub sub category
                        var subsubcategories = this.db.Categories.Where(x => x.ParentId == subcategory.Id).ToList();

                        if ( subcategories.Count > 0 )
                        {
                            foreach (var ssc in subsubcategories)
                            {
                                categoryIds.Add( ssc.Id );
                            }                            
                        }

                        categoryIds.Add(subcategory.Id);
                    }
                }


                query = query.Where(x => categoryIds.Contains( x.CategoryId ));
            }




            return query.OrderBy(x => x.Id)
                .Skip(offSet)
                .Take(limit).ToList();
            
        }


        public int GetTotalCount( int categoryId = 0 )
        {
            var query = this.db.Products
                            .Where(x => x.StatusId == 1);

            // FILTER
            if (categoryId != 0)
            {
                var categoryIds = new List<int>();

                categoryIds.Add(categoryId);

                // Find subcategories
                var subcategories = this.db.Categories.Where(x => x.ParentId == categoryId).ToList();
                if (subcategories.Count > 0)
                {
                    foreach (var subcategory in subcategories)
                    {
                        // Find Sub sub category
                        var subsubcategories = this.db.Categories.Where(x => x.ParentId == subcategory.Id).ToList();

                        if (subcategories.Count > 0)
                        {
                            foreach (var ssc in subsubcategories)
                            {
                                categoryIds.Add(ssc.Id);
                            }
                        }

                        categoryIds.Add(subcategory.Id);
                    }
                }


                query = query.Where(x => categoryIds.Contains(x.CategoryId));
            }

            return query.Count();
        }


        /**
         * @return Product
         */
        public Product GetOne( int Id )
        {
            return this.db.Products.FirstOrDefault( x=> x.Id == Id );
        }


        public void Create( Product product )
        {
            this.db.Products.Add(product);
            this.db.SaveChanges();            
        }


        /**
         * EDIT
         */
        public void Edit( int productId, Product product)
        {

            var result = this.db.Products.SingleOrDefault(x => x.Id == productId);
            if ( result != null ) {
                result.Title = product.Title;
                result.Price = product.Price;
                result.Count = product.Count;
                this.db.SaveChanges();
            }   
        }

        /**
         * ACTION: DELETE
         */
        public void Delete( int productId )
        {
            var item = this.db.Products.SingleOrDefault(x => x.Id == productId);
            if (item != null )
            {
                this.db.Products.Remove(item);
                this.db.SaveChanges();
            }
        }
    }
}