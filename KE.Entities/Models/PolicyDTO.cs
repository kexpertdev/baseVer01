using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Models
{
    public class PolicyDTO
    {
        public long ID { get; set; }
        [Display(Name = "Policy number"), Required, StringLength(50)]
        public string PolicyNumber { get; set; }


        [Display(Name = "Policy start date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PolicyStartDate { get; set; }
        [Display(Name = "Policy end date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PolicyEndDate { get; set; }
        [Display(Name = "Cancelled at date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? CancelledAtDate { get; set; }
        [Display(Name = "Cancelled from date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? CancelledFromDate { get; set; }
        [Display(Name = "Is fixed term"), Required]
        public bool IsFixedTerm { get; set; }


        public int Product_ID { get; set; }
        public int Status_ID { get; set; }
        public int Broker_ID { get; set; }
        public int Client_ID { get; set; }
        public int Vehicle_ID { get; set; }
        public int? CancellationReason_ID { get; set; }
        public int? ModificationReason_ID { get; set; }
        public int CreatedBy_ID { get; set; }
        public int? ModifiedBy_ID { get; set; }


        [Display(Name = "Created at"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Modified at"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? Modified { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
        public string ModifiedReason { get; set; }


        //addings
        public long LastPolicyPeriodID { get; set; }


        public override string ToString()
        {
            return "[" + ID + "] " + PolicyNumber;
        }
    }
}
