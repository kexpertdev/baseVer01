using KE.BusinessLayer;
using KE.Entities.Emuns;
using KE.Entities.WsMobile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace KExpert.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IPolicyService service) : base(service)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendFile(string base64String, string filename, string mime)
        {
            var imageSetCollection = new ImageSetCollection()
            {
                ImageSets = new List<ImageSet>() {
                    new ImageSet()
                    {
                        Name = "test",
                        ImageSetType = ClaimImageSetTypes.BackSidePictures,
                        Images = new List<Image>() { 
                            new Image() 
                                {
                                    FileName = filename,
                                    MimeType = mime,
                                    //ImageData = Convert.FromBase64String(base64),
                                    Base64Image = base64String
                                } 
                        }
                    }
                }
            };
            
            var service = new ApiServiceReference.MobileServiceClient("api");
            var result = service.UploadImageSets(imageSetCollection);
            //var result = service.PostBase64(base64);

            return View("Index");
        }
    }
}