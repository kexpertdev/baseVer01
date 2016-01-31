[assembly: WebActivator.PreApplicationStartMethod(typeof(KExpert.Ws.App_Start.PreApplicationStartMethod), "Start")]

namespace KExpert.Ws.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;
    using KExpert.Ws.Mapping;


        public class PreApplicationStartMethod
        {
            public static void Start()
            {
                //var config = HttpHostConfiguration.Create()
                //    .AddFormatters(new ImageSetMediaTypeFormatter());
                //RouteTable.Routes.MapServiceRoute<Service>("service", config);
            }
        }
}