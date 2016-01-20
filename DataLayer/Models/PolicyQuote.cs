using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("PolicyQuote")]
    public class PolicyQuote
    {
        [Key]
        public long ID { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }


        public string PolicyType { get; set; }
        public DateTimeOffset PolicyStartingDate { get; set; }
        public int PolicyNrOfMonthsValid { get; set; }
        public string PolicyPaymentMethod { get; set; }
        public string VehicleType { get; set; }
        public string VehicleUsage { get; set; }
        public bool ContractorIsLegalPerson { get; set; }
        public string PostalCode { get; set; }
        public string RequestUrl { get; set; }

        
        public int ResultedQuotePremium { get; set; }
        public DateTimeOffset PolicyEndingDate { get; set; }
        public string ClientCodeGenerated { get; set; }
        public string PaymentUrl { get; set; }


        public virtual Product Product { get; set; }
        public virtual Broker Broker { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
