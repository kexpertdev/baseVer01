using KExpertService.WsModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KExpertService.WsModels.Response
{
    [DataContract]
    public class PolicyQuoteResponse
    {
        [DataMember]
        public int ResultedQuotePremium { get; set; }
        [DataMember]
        public DateTimeOffset PolicyEndingDate { get; set; }
        [DataMember]
        public string ClientCodeGenerated { get; set; }
        [DataMember]
        public string PaymentUrl { get; set; }


        public PolicyQuoteRequest PolicyQuoteRequest { get; set; }


        [DataMember]
        public DateTimeOffset CreatedDate { get; set; }
    }
}