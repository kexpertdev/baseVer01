using KE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Emuns
{
    [DataContract(Namespace = WsConfig.SharedShemaNamespace)]
    public enum PolicyPaymentMethods : int
    {
        [EnumMember]
        Cheque = 1,
        [EnumMember]
        Transfer = 2,
        [EnumMember]
        DirectDebit = 3,
        [EnumMember]
        BankCard = 4
    }
}
