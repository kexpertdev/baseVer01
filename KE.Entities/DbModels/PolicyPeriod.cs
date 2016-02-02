using KE.Entities.Emuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("PolicyPeriod")]
    public class PolicyPeriod : BaseModel
    {
        [Key]
        public long ID { get; set; }


        [Display(Name = "Period start date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset PeriodStartDate { get; set; }
        [Display(Name = "Period end date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset PeriodEndDate { get; set; }
        [Display(Name = "Premium"), Required]
        public decimal Premium { get; set; }
        [Display(Name = "Is Last period"), Required]
        public bool IsLastPeriod { get; set; }
        [Display(Name = "Period number"), Required]
        public int PeriodNumber { get; set; }


        //[Required]
        //public int Broker_ID { get; set; }
        [ForeignKey("Policy"), Required]
        public long Policy_ID { get; set; }
        [ForeignKey("Quote"), Required]
        public Guid Quote_ID { get; set; }
        [ForeignKey("PaymentType"), Required]
        public int PaymentType_ID { get; set; }
        [ForeignKey("PreviousPolicyPeriod")]
        public long? PreviousPolicyPeriod_ID { get; set; }


        //public virtual Broker Broker { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual PolicyQuote Quote { get; set; }
        public virtual PolicyPaymentType PaymentType { get; set; }
        public virtual PolicyPeriod PreviousPolicyPeriod { get; set; }
        public virtual ICollection<PolicyInstallment> Installment { get; set; }
        public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; }

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
            return Policy.PolicyNumber + ", premium: " + Premium.ToString() + ", " + PeriodStartDate.ToString() + " - " + PeriodEndDate.ToString();
        }
    }
}
