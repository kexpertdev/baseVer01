using KE.BusinessLayer;
using KE.Entities;
using KE.Entities.WsMobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace KExpert.Ws
{
        
    [ServiceContract(Namespace = WsConfig.ServiceNamespace, SessionMode = SessionMode.Allowed)]
    public interface IMobileService
    {
        [OperationContract]
        PolicyDetails GetPolicyDetails(string policyId);

        [OperationContract]
        bool SaveClaimDocuments(string policyId);

        [OperationContract]
        ImageSetCollection GetImageThumbnails(string policyId);

        [OperationContract]
        Image GetFullImage(string guid);

        [OperationContract]
        [WebInvoke(UriTemplate = "UploadImageSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        bool UploadImageSets(ImageSetCollection imageSetCollection);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "PostBase64", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string PostBase64(string base64);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetBase64", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetBase64(string guid);
    }
}
