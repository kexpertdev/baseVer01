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


        [Display(Name = "Period start date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PeriodStartDate { get; set; }
        [Display(Name = "Period end date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PeriodEndDate { get; set; }
        [Display(Name = "Premium"), Required]
        public decimal Premium { get; set; }
        [Display(Name = "Is Last period"), Required]
        public bool IsLastPeriod { get; set; }
        [Display(Name = "Period number"), Required]
        public int PeriodNumber { get; set; }


        [Display(Name = "Insurer company"), StringLength(50)]
        public string InsurerCompany { get; set; }
        [Display(Name = "Insurer policy number"), StringLength(50)]
        public string InsurerPolicyNumber { get; set; }
        [Display(Name = "Insurance start date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset InsuranceStartDate { get; set; }
        [Display(Name = "Insurance end date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset InsuranceEndDate { get; set; }


        [Required]
        public int Broker_ID { get; set; }


        public virtual Policy Policy { get; set; }
        public virtual PolicyQuote Quote { get; set; }
        public virtual PolicyPaymentType PaymentType { get; set; }
        public virtual PolicyPeriod PreviousPolicyPeriod { get; set; }
        //public virtual Broker Broker { get; set; }
        

        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
        [Display(Name = "Modified date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedDate { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
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
