using KE.BusinessLayer;
using KE.Entities;
using KE.Entities.WsMobile;
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
        [OperationContract]
        string GetServertime();

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        Task<PolicyQuoteResponse> GetQuotationAsync(PolicyQuoteRequest inputParameters);

        [OperationContract]
        PolicyQuoteResponse GetQuote(PolicyQuoteRequest inputParameters);

        [OperationContract]
        CreatePolicyResponse CreatePolicy(CreatePolicyRequest inputParameters);

        //[OperationContract]
        //void RenewingPolicy();



        //Mobile
        //TODO refact, separete from brokers webservice
        //[OperationContract]
        //PolicyDetails GetPolicyDetails(string policyId);

        //[OperationContract]
        //bool SaveClaimDocuments(string policyId);

        //[OperationContract]
        //ImageSetCollection GetImageThumbnails(string policyId);

        //[OperationContract]
        //Image GetFullImage(string guid);
        
        //[OperationContract]
        //[WebInvoke(UriTemplate = "UploadImageSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        //bool UploadImageSets(ImageSetCollection imageSetCollection);

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "PostBase64", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        //string PostBase64(string base64);

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "GetBase64", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //string GetBase64(string guid);
    }
}
