using KE.Entities.DbModels;
using KE.Entities;
using KE.Entities.WsModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.WsModels
{
    [DataContract(Namespace = WsConfig.ShemaNamespace)]
    public class CreatePolicyRequest
    {
        [DataMember(Order = 0, IsRequired = true), Required]
        public Guid QuoteGuid { get; set; }
        [DataMember(Order = 1, IsRequired = true), Required]
        public WsVehicle Vehicle { get; set; }
        [DataMember(Order = 2, IsRequired = true), Required]
        public WsClient Client { get; set; }


    }
}
