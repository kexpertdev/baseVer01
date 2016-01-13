using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("PolicyPeriod")]
    public class PolicyPeriod
    {
        [Key]
        public long ID { get; set; }


        public DateTimeOffset PeriodStart { get; set; }
        public DateTimeOffset PeriodEnd { get; set; }
        public decimal Premium { get; set; }
        public bool IsLastPeriod { get; set; }
        public int PeriodNumber { get; set; }


        public Policy Policy { get; set; }
        public PolicyQuote Quote { get; set; }
        public PaymentType PaymentType { get; set; }
        public Broker Broker { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
        public string LastModifiedReason { get; set; }


        public override string ToString()
        {
            return Policy.PolicyNumber + " - " + PeriodStart.ToString("YYYY-MM-DD") + ", " + PeriodEnd.ToString("YYYY-MM-DD");
        }
    }
}
