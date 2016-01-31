using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.WsModels.Base
{
    [DataContract(Name = "Address", Namespace = WsConfig.SharedShemaNamespace)]
    public class WsAddress
    {
        [DataMember(Order = 0), Required, MaxLength(4), MinLength(4)]
        public string PostalCode { get; set; }
        [DataMember(Order = 1), Required, StringLength(100)]
        public string City { get; set; }
        [DataMember(Order = 2), Required, StringLength(100)]
        public string StreetName { get; set; }
        [DataMember(Order = 3), Required, StringLength(25)]
        public string StreetNumber { get; set; }
    }
}
