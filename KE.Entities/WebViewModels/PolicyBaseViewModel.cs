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
        public PolicyDto Policy { get; set; }
        public PolicyPeriodDto PolicyPeriod { get; set; }
    }
}
