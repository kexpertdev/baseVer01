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
    [Table("Policy")]
    public class Policy : BaseModel
    {
        [Key]
        public long ID { get; set; }
        [Display(Name = "Policy number"), Required, Index(IsUnique = true), StringLength(50)]
        public string PolicyNumber { get; set; }


        [Display(Name = "Policy start date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset PolicyStartDate { get; set; }
        [Display(Name = "Policy end date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset PolicyEndDate { get; set; }
        [Display(Name = "Cancelled at date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? CancelledAtDate { get; set; }
        [Display(Name = "Cancelled from date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? CancelledFromDate { get; set; }
        [Display(Name = "Policy type"), Required]
        public bool IsFixedTerm { get; set; }


        [ForeignKey("Product"), Required]
        public int Product_ID { get; set; }
        [ForeignKey("Status"), Required]
        public int Status_ID { get; set; }
        [ForeignKey("Broker"), Required]
        public int Broker_ID { get; set; }
        [ForeignKey("Client"), Required]
        public long Client_ID { get; set; }
        [ForeignKey("Vehicle"), Required]
        public long Vehicle_ID { get; set; }
        [ForeignKey("CancellationReason")]
        public int? CancellationReason_ID { get; set; }
        [ForeignKey("ModificationReason")]
        public int? ModificationReason_ID { get; set; }
        [ForeignKey("CreatedBy"), Required]
        public int CreatedBy_ID { get; set; }
        [ForeignKey("ModifiedBy")]
        public int? ModifiedBy_ID { get; set; }


        public virtual Product Product { get; set; }
        public virtual PolicyStatus Status { get; set; }
        public virtual Broker Broker { get; set; }
        public virtual Client Client { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual PolicyCancellationReason CancellationReason { get; set; }
        public virtual PolicyModificationReason ModificationReason { get; set; }
        public virtual AppUser CreatedBy { get; set; }
        public virtual AppUser ModifiedBy { get; set; }
        public virtual ICollection<PolicyPeriod> PolicyPeriods { get; set; }


        public override string ToString()
        {
            return PolicyNumber + " - " + Vehicle.PalateNumber + ", Status = " + Status.Name;
        }
    }
}
