using KE.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Emuns
{
    [DataContract(Namespace = WsConfig.SharedShemaNamespace)] 
    public enum VehicleUsages : int
    {
         /// <summary>
        /// Normál
        /// </summary>
        [EnumMember]
        Normal = 1,

        /// <summary>
        /// Taxi
        /// </summary>
        [EnumMember]
        Taxi,

        /// <summary>
        /// Versenyautó
        /// </summary>
        [EnumMember]
        RacingCar,

        /// <summary>
        /// Kölcsön gépjármű
        /// </summary>
        [EnumMember]
        Renting,

        /// <summary>
        /// Oktató autó
        /// </summary>
        [EnumMember]
        DrivingSchool,

        /// <summary>
        /// Hadsereg
        /// </summary>
        [EnumMember]
        Military,

        /// <summary>
        /// Páncélozott vagy értékszállító jármű
        /// </summary>
        [EnumMember]
        ArmoredCar,

        /// <summary>
        /// Mentő
        /// </summary>
        [EnumMember]
        Ambulance,

        /// <summary>
        /// Rendőrségi
        /// </summary>
        [EnumMember]
        Police,

        /// <summary>
        /// Tűzoltó
        /// </summary>
        [EnumMember]
        FiremanTruck,

        /// <summary>
        /// Építkezésen
        /// </summary>
        [EnumMember]
        Constructions,

        /// <summary>
        /// Repülőtéri
        /// </summary>
        [EnumMember]
        Airport,

        /// <summary>
        /// Veszélyes anyag szállítás
        /// </summary>
        [EnumMember]
        HazardousMaterialTransport,

        /// <summary>
        /// Nemzetközi árú fuvarozás
        /// </summary>
        [EnumMember]
        InternationalGoodsTransport,

        /// <summary>
        /// VehicleMarkedWithBlueLightsAndSiren
        /// </summary>
        [EnumMember]
        VehicleMarkedWithBlueLightsAndSiren
    }
}
