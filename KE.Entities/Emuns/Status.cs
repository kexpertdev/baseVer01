using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Emuns
{
    public enum Status : byte
    {
        [EnumMember]
        Inactive = 0,
        [EnumMember]
        Active = 1
    }
}
