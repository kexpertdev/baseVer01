using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.WsModels
{
    public class ValidStartDateAttribute : RangeAttribute
    {
        public ValidStartDateAttribute()
            : base(typeof(DateTime), DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(60).ToShortDateString()) { }
    }
}
