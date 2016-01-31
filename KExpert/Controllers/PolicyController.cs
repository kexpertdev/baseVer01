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
         private readonly IPolicyService _service;

        public IPolicyService Service
        {
            get
            {
                return _service;
            }
        }

        public PolicyController(IPolicyService service) 
        {
            if (service == null) throw new ArgumentNullException("IPolicyService");
            _service = service;
        }

        public ActionResult Index()
        {
            var model = Service.GetPolicyBaseModel(2);

            return View();
        }
    }
}