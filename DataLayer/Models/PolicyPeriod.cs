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


        public DateTimeOffset PeriodStartDate { get; set; }
        public DateTimeOffset PeriodEndDate { get; set; }
        public decimal Premium { get; set; }
        public bool IsLastPeriod { get; set; }
        public int PeriodNumber { get; set; }

        public string InsuranceCompany { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTimeOffset InsuranceStartDate { get; set; }
        public DateTimeOffset InsuranceEndDate { get; set; }


        public virtual Policy Policy { get; set; }
        public virtual PolicyQuote Quote { get; set; }
        public virtual PolicyPaymentType PaymentType { get; set; }
        public virtual Broker Broker { get; set; }
        

        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
        [Display(Name = "Modified date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedDate { get; set; }
        [Display(Name = "Modified reason")]
        public string ModifiedReason { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        [Display(Name = "Is first period"), NotMapped]
        public bool IsFirstPeriod
        {
            get
            {
                return PeriodNumber == 1;
            }

        }


        public override string ToString()
        {
            return Policy.PolicyNumber + " - " + PeriodStartDate.ToString() + ", " + PeriodEndDate.ToString();
        }
    }
}
