using KE.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Emuns
{
    /// <summary>
    /// MtplVehicleTypes
    /// </summary>
    [DataContract(Namespace = WsConfig.SharedShemaNamespace)]
    public enum VehicleTypes : int
    {
        /// <summary>
        /// Személygépkocsi
        /// </summary>
        [EnumMember]
        Automobile = 1,

        /// <summary>
        /// Motorkerékpár
        /// </summary>
        [EnumMember]
        Motorcycle = 2,

        /// <summary>
        /// Tehergépkocsi
        /// </summary>
        [EnumMember]
        Truck = 3,

        /// <summary>
        /// Autóbusz
        /// </summary>
        [EnumMember]
        Bus = 4,

        /// <summary>
        /// Nyerges vontató
        /// </summary>
        [EnumMember]
        RoadTractor = 5,

        /// <summary>
        /// Munkagép
        /// </summary>
        [EnumMember]
        Machinery = 6,

        /// <summary>
        /// Trolibusz
        /// </summary>
        [EnumMember]
        Trolleybus = 7,

        /// <summary>
        /// Quad
        /// </summary>
        [EnumMember]
        Quad = 8,

        /// <summary>
        /// Segédmotoros kerékpár
        /// </summary>
        [EnumMember]
        Moped = 9,

        /// <summary>
        /// Mezőgazdasági vontató
        /// </summary>
        [EnumMember]
        AgriculturalTractor = 10,

        /// <summary>
        /// Lassú jármű
        /// </summary>
        [EnumMember]
        SlowVehicle = 11,

        /// <summary>
        /// Könnyű pótkocsi, utánfutó, Nehéz pótkocsi, Motorkerékpár utánfutó
        /// </summary>
        [EnumMember]
        Trailer = 12,

        /// <summary>
        /// Félpótkocsi
        /// </summary>
        [EnumMember]
        SemiTrailer = 13,

        /// <summary>
        /// Lakókocsi
        /// </summary>
        [EnumMember]
        Caravan = 14,

        /// <summary>
        /// Ideiglenes rendszám
        /// </summary>
        [EnumMember]
        TemporaryNumberPlates = 15
    }
}
