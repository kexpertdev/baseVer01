using KE.Entities.Emuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Models
{
    public class PolicyPeriodDto
    {
        public long ID { get; set; }


        [Display(Name = "Period start date"), Required, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTimeOffset PeriodStartDate { get; set; }
        [Display(Name = "Period end date"), Required, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTimeOffset PeriodEndDate { get; set; }
        [Display(Name = "Premium"), Required, DisplayFormat(DataFormatString = "{0:####}")]
        public decimal Premium { get; set; }
        [Display(Name = "Is Last period"), Required]
        public bool IsLastPeriod { get; set; }
        [Display(Name = "Period number"), Required]
        public int PeriodNumber { get; set; }


        //[Display(Name = "Insurer company"), StringLength(50)]
        //public string InsurerCompany { get; set; }
        //[Display(Name = "Insurer policy number"), StringLength(50)]
        //public string InsurerPolicyNumber { get; set; }
        //[Display(Name = "Insurance start date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTimeOffset InsuranceStartDate { get; set; }
        //[Display(Name = "Insurance end date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTimeOffset InsuranceEndDate { get; set; }


        
        //public int Broker_ID { get; set; }
        [Required]
        public int Policy_ID { get; set; }
        [Required]
        public Guid Quote_ID { get; set; }
        [Required]
        public int PaymentType_ID { get; set; }
        public long? PreviousPolicyPeriod_ID { get; set; }
        //addings
        //public long NextPolicyPeriod_ID { get; set; }


        [Display(Name = "Created at"), Required, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}")]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Modified at"), DisplayFormat(DataFormatString = "{0:yyy-MM-dd H:mm}")]
        public DateTimeOffset? Modified { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
        public string ModifiedReason { get; set; }


        [Display(Name = "Is first period")]
        public bool IsFirstPeriod { get; set; }


        //addings
        public PolicyPaymentMethods PaymentMethod { get; set; }



        public override string ToString()
        {
            return "[" + ID + "] " + PeriodStartDate.ToString() + ", " + PeriodEndDate.ToString();
        }
    }
}
