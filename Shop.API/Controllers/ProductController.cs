using System.Web.Mvc;


namespace Shop.API.Controllers
{
    using Shop.BLL;
    using Shop.BLL.ViewModels;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Shop.DAL.Models;


    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private ProductBLL _bll;

        public ProductController()
        {
            this._bll = new ProductBLL();
        }



        // GET: Category
        [HttpGet]
        [Route("list")]
        public List<Product> GetList(int pageNumber = 1, int limit = 3, int categoryId = 0)
        {            
            return this._bll.getList( pageNumber, limit = 3, categoryId);
        }


        /**
         * 
         */
        [HttpGet]
        [Route("count")]
        public int GetTotalCount( int categoryId = 0 )
        {            
            return this._bll.getTotalCount( categoryId);            
        }


        [HttpGet]
        [Route("details")]
        public Product GetOne(int productId = 0)
        {
            return this._bll.getOne( productId );
        }


        [HttpPost]
        [Route("create")]
        public void Create(Product product)
        {
            this._bll.Create(product);
        }


        [HttpPost]
        [Route("edit")]
        public void Edit( int productId, Product product)
        {
            this._bll.Edit( productId, product);
        }


        [HttpPost]
        [Route("delete")]
        public void Delete(int productId)
        {
            this._bll.Delete(productId);
        }

    }
}