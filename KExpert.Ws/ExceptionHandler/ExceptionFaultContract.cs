using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KExpert.Ws.ExceptionHandler
{
    [Serializable]
    public class ExceptionFaultContract
    {
        [DataMember(Name="StatusCode")]
        public string StatusCode { get; set; }

        [DataMember(Name = "Message")]
        public string Message { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }

        public ExceptionFaultContract(string statusCode, string message, string description)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Description = description;
        }
    }
}