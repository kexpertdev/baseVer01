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
        public string InsuranceCompany { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public DateTimeOffset PolicyStart { get; set; }
        public DateTimeOffset PolicyEnd { get; set; }
        public DateTimeOffset CancelledAt { get; set; }
        public DateTimeOffset CancelledFrom { get; set; }
        public bool IsLimitedTerm { get; set; }

        public Product Product { get; set; }
        public PolicyStatus Status { get; set; }
        public PolicyCancellationReason CancellationReason { get; set; }
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
        //lastmodifuser
        public DateTimeOffset LastModifiedDate { get; set; }
        public string LastModifiedReason { get; set; }


        public override string ToString()
        {
            return PolicyNumber + " - " + Vehicle.PalateNumber + ", " + Status.Name;
        }
    }
}
