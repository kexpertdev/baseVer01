using KE.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Enums
{
    /// <summary>
    /// Gender
    /// </summary>
    [DataContract(Namespace = WsConfig.SharedShemaNamespace)] 
    public enum Gender : int
    {
        /// <summary>
        /// NotApplicable is used when customer is commercial company (legal entity)
        /// </summary>
        [EnumMember]
        NotApplicable = 0,
        [EnumMember]
        Male = 1,
        [EnumMember]
        Female = 2,
    }
}
