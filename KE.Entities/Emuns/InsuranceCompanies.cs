using KE.Entities.Shared;
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
        Generali = 5,
        [EnumMember]
        Genertel = 6,
        [EnumMember]
        Groupama = 7,
        [EnumMember]
        KH = 8,
        [EnumMember]
        KOBE = 9,
        [EnumMember]
        MagyarPosta = 10,
        [EnumMember]
        MKB = 11,
        [EnumMember]
        SIGNAL = 12,
        [EnumMember]
        UNION = 13,
        [EnumMember]
        Uniqa = 14,
        [EnumMember]
        WABARD = 15,
        [EnumMember]
        GroupamaGarancia = 16
    }
}
