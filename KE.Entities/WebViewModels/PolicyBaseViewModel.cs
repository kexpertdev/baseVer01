using KE.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.WebViewModels
{
    /// <summary>
    /// PolicyBaseViewModel
    /// </summary>
    public class PolicyBaseViewModel
    {
        public PolicyDTO Policy { get; set; }
        public PolicyPeriodDTO PolicyPeriod { get; set; }
    }
}
