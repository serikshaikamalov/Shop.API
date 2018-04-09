using System.Web.Mvc;


namespace Shop.API.Controllers
{
    using Shop.BLL;
    using Shop.BLL.ViewModels;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Cors;


    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private CategoryBLL _bll;

        public CategoryController()
        {
            this._bll = new CategoryBLL();
        }



        // GET: Category
        [HttpGet]
        [Route("list")]
        public List<CategoryVM> GetList()
        {            
            return this._bll.getList();
        }
    }
}