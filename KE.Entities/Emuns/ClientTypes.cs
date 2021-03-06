﻿using KE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Emuns
{
    [DataContract(Namespace = WsConfig.SharedShemaNamespace)]
    public enum ClientTypes : int
    {
        [EnumMember]
        Owner = 1,
        [EnumMember]
        RegisteredKeeper = 2,
        [EnumMember]
        Beneficiary = 3
    }
}
