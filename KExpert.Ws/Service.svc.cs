using DevTrends.WCFDataAnnotations;
using KE.BusinessLayer;
using KE.Entities.DbModels;
using KE.Entities.WsModels;
using KExpert.Ws.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KExpert.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [ValidateDataAnnotationsBehavior]
    public class Service : IService
    {
        public string HelloWorld()
        {
            return "Hello World from KexpertWS";
        }

        public string GetServertime()
        {
            return DateTime.Now.ToString();
        }

        public async Task<PolicyQuoteResponse> GetQuoteAsync(PolicyQuoteRequest inputParameters)
        {
            PolicyQuoteResponse policyQuoteResponse;
            try
            {
                int num = HttpContext.Current.User.Identity.IsAuthenticated ? 1 : 0;
                IIdentity primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity;
                AppUser user = (AppUser)null;
                await Task.Delay(1);
                WsService WS = new WsService();
                PolicyQuoteResponse resp = WS.GetQuote(inputParameters, user);
                policyQuoteResponse = resp;
            }
            catch (Exception ex)
            {
                throw new FaultException<ExceptionFaultContract>(new ExceptionFaultContract("GetQuote", "message", "description"));
            }
            return policyQuoteResponse;
        }

        //[WebInvoke]
        public PolicyQuoteResponse GetPolicyQuote(PolicyQuoteRequest inputParameters)
        {
            try
            {
                IIdentity primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity;
                AppUser user = (AppUser)null;
                return new WsService().GetQuote(inputParameters, user);
            }
            catch (Exception ex)
            {
                throw new FaultException("GetQuote error description");
            }
        }
    }
}
