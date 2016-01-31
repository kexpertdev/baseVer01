using KE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Enums
{
    [DataContract(Namespace = WsConfig.SharedShemaNamespace)]
    public enum InsuranceCompanies : int
    {
        [EnumMember]
        Other = 0,
        [EnumMember]
        AEGON = 1,
        [EnumMember]
        AIM = 2,
        [EnumMember]
        Allianz = 3,
        [EnumMember]
        Generali = 4,
        [EnumMember]
        Genertel = 5,
        [EnumMember]
        Groupama = 6,
        [EnumMember]
        KH = 7,
        [EnumMember]
        KOBE = 8,
        [EnumMember]
        MagyarPosta = 9,
        [EnumMember]
        MKB = 10,
        [EnumMember]
        SIGNAL = 11,
        [EnumMember]
        UNION = 12,
        [EnumMember]
        Uniqa = 13,
        [EnumMember]
        WABARD = 14
    }
}
