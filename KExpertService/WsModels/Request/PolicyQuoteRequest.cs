using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KExpertService.WsModels.Request
{
    [DataContract]
    public class PolicyQuoteRequest
    {
        [DataMember]
        public string PolicyType { get; set; }
        [DataMember]
        public DateTimeOffset PolicyStartingDate { get; set; }
        [DataMember]
        public int PolicyNrOfMonthsValid { get; set; }
        [DataMember]
        public string PolicyPaymentMethod { get; set; }
        [DataMember]
        public string VehicleType { get; set; }
        [DataMember]
        public string VehicleUsage { get; set; }
        [DataMember]
        public bool ContractorIsLegalPerson { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string RequestUrl { get; set; }
        [DataMember]
        public string Product { get; set; }
        [DataMember]
        public string Broker { get; set; }
    }
}