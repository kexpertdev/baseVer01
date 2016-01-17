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


        public string PolicyNumber { get; set; }
      
        public DateTimeOffset PolicyStartDate { get; set; }
        public DateTimeOffset PolicyEndDate { get; set; }
        public DateTimeOffset CancelledAtDate { get; set; }
        public DateTimeOffset CancelledFromDate { get; set; }
        public bool IsLimitedTerm { get; set; }

        public virtual Product Product { get; set; }
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
        [Display(Name = "Modified reason")]
        public string ModifiedReason { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return PolicyNumber + " - " + Vehicle.PalateNumber + ", " + Status.Name;
        }
    }
}
