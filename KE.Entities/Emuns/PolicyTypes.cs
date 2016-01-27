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
    public enum PolicyTypes : int
    {
        [EnumMember]
        Normal = 1,
        [EnumMember]
        FixedTerm = 2
    }
}
