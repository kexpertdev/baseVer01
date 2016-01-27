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
    public enum Products : int
    {
        [EnumMember] 
        Kgfb = 1,
        [EnumMember]
        Casco = 2,
        [EnumMember]
        KgfbCasco = 3
    }
}
