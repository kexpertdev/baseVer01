using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("PolicyInstallment")]
    public class PolicyInstallment : BaseModel
    {
        [Key]
        public long ID { get; set; }


        [Display(Name = "Installment number"), Required]
        public int Nr { get; set; }
        [Display(Name = "Installment type"), Required]
        public int Type { get; set; }
        [Display(Name = "Installment due date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset DueDate { get; set; }
        [Display(Name = "Installment value"), Required, DisplayFormat(DataFormatString = "{0.##}")]
        public decimal Value { get; set; }
        [Display(Name = "Income value"), Required, DisplayFormat(DataFormatString = "{0.##}")]
        public decimal IncomeValue { get; set; }
        [Display(Name = "Payed date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset PayedDate { get; set; }
        [Display(Name = "Is paid"), Required]
        public bool IsPaid { get; set; }
        [Display(Name = "Cheque sent to print date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset ChequeSentToPrint { get; set; }
        [Display(Name = "Cheque resent to print date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset ChequeReSentToPrint { get; set; }


        [ForeignKey("PolicyPeriod"), Required]
        public long PolicyPeriod_ID { get; set; }
        [ForeignKey("ModifiedBy")]
        public int? ModifiedBy_ID { get; set; }


        public virtual PolicyPeriod PolicyPeriod { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return DueDate.ToString() + " - " + Value.ToString();
        }
    }
}
