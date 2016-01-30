using KE.Entities.Emuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.WsModels.Base
{
    [DataContract(Name = "Vehicle", Namespace = WsConfig.SharedShemaNamespace)]
    public class WsVehicle
    {
        [DataMember(Order = 0, IsRequired = true), Required, MaxLength(25)]
        public string PalateNumber { get; set; }
        [DataMember(Order = 1, IsRequired = true), Required, MaxLength(50)]
        public string VIN { get; set; }
        [DataMember(Order = 2, IsRequired = true), Required, MaxLength(25)]
        public string RegistrationCertificateNumber { get; set; }
        [DataMember(Order = 3, IsRequired = true), Required, MaxLength(100)]
        public string Make { get; set; }
        [DataMember(Order = 4, IsRequired = true), Required, MaxLength(100)]
        public string Model { get; set; }
        [DataMember(Order = 5, IsRequired = true), Required]
        public VehicleTypes Type { get; set; }
        [DataMember(Order = 6, IsRequired = true), Required]
        public VehicleUsages Usage { get; set; }
        [DataMember(Order = 7, IsRequired = true), Required, MaxLength(50)]
        public string Color { get; set; }
    }
}
