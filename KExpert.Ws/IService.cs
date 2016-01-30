using KE.BusinessLayer;
using KE.Entities;
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

    [ServiceContract(Namespace = WsConfig.ServiceNamespace, SessionMode = SessionMode.Allowed)]
    //[ServiceContract]
    public interface IService
    {
        IWsService WS { get; }


        [OperationContract]
        string GetServertime();

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        Task<PolicyQuoteResponse> GetQuotationAsync(PolicyQuoteRequest inputParameters);

        [OperationContract]
        PolicyQuoteResponse GetQuote(PolicyQuoteRequest inputParameters);

        [OperationContract]
        CreatePolicyResponse CreatePolicy(CreatePolicyRequest inputParameters);
    }
}
