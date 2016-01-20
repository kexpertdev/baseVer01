using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KExpert.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IService service = new BaseService(new KexpertDbRepository());
            var p = service.GetAllPolicy();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}