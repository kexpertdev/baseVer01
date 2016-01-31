using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KExpert.Ws.ExceptionHandler
{
    [DataContract(Name = "ExceptionFaultContract")]
    public class ExceptionFaultContract
    {
        [DataMember(Name="StatusCode", Order = 0)]
        public string StatusCode { get; set; }

        [DataMember(Name = "Message", Order = 1)]
        public string Message { get; set; }

        [DataMember(Name = "Description", Order = 2)]
        public string Description { get; set; }

        public ExceptionFaultContract(string statusCode, string message, string description)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Description = description;
        }
    }
}