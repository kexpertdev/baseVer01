using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Policy")]
    public class Policy
    {
        [Key]
        public long ID { get; set; }


        [Display(Name = "Policy number"), StringLength(50)]
        public string PolicyNumber { get; set; }


        [Display(Name = "Policy start date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PolicyStartDate { get; set; }
        [Display(Name = "Policy end date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PolicyEndDate { get; set; }
        [Display(Name = "Cancelled at date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CancelledAtDate { get; set; }
        [Display(Name = "Cancelled from date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CancelledFromDate { get; set; }
        [Display(Name = "Is fixed term"), Required]
        public bool IsFixedTerm { get; set; }


        public virtual Product Product { get; set; }
        public virtual Broker Broker { get; set; }
        public virtual Client Client { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual PolicyStatus Status { get; set; }
        public virtual PolicyCancellationReason CancellationReason { get; set; }
        public virtual PolicyModificationReason ModificationReason { get; set; }
        public virtual ICollection<PolicyPeriod> PolicyPeriods { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
        [Display(Name = "Modified date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedDate { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
        public string ModifiedReason { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return PolicyNumber + " - " + Vehicle.PalateNumber + ", " + Status.Name;
        }
    }
}
