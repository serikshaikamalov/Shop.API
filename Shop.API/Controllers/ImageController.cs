using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Shop.DAL.Models;
using Shop.DAL;

namespace Shop.API.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ImageController : ApiController
    {

        [HttpPost]
        [Route("api/UploadImage")]
        public Image UploadImage()
        {                 
            var image = new Image();

            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);

            //Save to DB
            using (ShopContext db = new ShopContext())
            {

                image.ImageCaption = httpRequest["ImageCaption"];
                image.ImageName = imageName;
               
                db.Images.Add(image);
                db.SaveChanges();                
            }

            return image;
        }
    }
}