using KE.Entities.WsModels;
using KExpert.Ws.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace KExpert.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    //[ServiceContract(Namespace = "http://karexpert.hu/kews/", SessionMode = SessionMode.Allowed)]
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        string HelloWorld();

        [OperationContract]
        string GetServertime();

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        Task<PolicyQuoteResponse> GetQuoteAsync(PolicyQuoteRequest inputParameters);

        [OperationContract]
        PolicyQuoteResponse GetPolicyQuote(PolicyQuoteRequest inputParameters);
    }
}
