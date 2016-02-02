using KE.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KExpert.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IPolicyService Service;


        public PolicyController(IPolicyService service) 
        {
            if (service == null) throw new ArgumentNullException("IPolicyService");
            Service = service;
        }

        public ActionResult Index(string searchString)
        {
            if(searchString != null && searchString != String.Empty)
            {
                var model = Service.GetPolicyBaseModel(searchString);
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}