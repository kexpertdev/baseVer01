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
        public long PrevID { get; set; }
        public long NextID { get; set; }


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


        [Display(Name = "Insurer company"), StringLength(50)]
        public string InsurerCompany { get; set; }
        [Display(Name = "Insurer policy number"), StringLength(50)]
        public string InsurerPolicyNumber { get; set; }
        [Display(Name = "Insurance start date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset InsuranceStartDate { get; set; }
        [Display(Name = "Insurance end date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset InsuranceEndDate { get; set; }


        
        //public int Broker_ID { get; set; }
        [Required]
        public int Policy_ID { get; set; }
        [Required]
        public int Quote_ID { get; set; }
        [Required]
        public int PaymentType_ID { get; set; }
        [Required]
        public int? PreviousPolicyPeriod_ID { get; set; }
        

        [Display(Name = "Created at"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Modified at"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? Modified { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
        public string ModifiedReason { get; set; }


        [Display(Name = "Is first period")]
        public bool IsFirstPeriod { get; set; }


        public override string ToString()
        {
            return "[" + ID + "] " + PeriodStartDate.ToString() + ", " + PeriodEndDate.ToString();
        }
    }
}
