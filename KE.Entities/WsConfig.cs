using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities
{
    public static class WsConfig
    {
        public static readonly string WsConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public const string ServiceNamespace = @"http://karexpert.hu/kews/";
        public const string ShemaNamespace = @"http://karexpert.hu/kews/types/";

        //public const string ServiceNamespace = @"http://localhost/kews/";
        //public const string ShemaNamespace = @"http://localhost/kews/types/";

        public const string SharedServiceNamespace = ServiceNamespace + @"shared/";
        public const string SharedShemaNamespace = SharedServiceNamespace + @"types/";
    }
}
