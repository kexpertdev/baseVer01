using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Claim")]
    public class Claim
    {
        [Key]
        public int ID { get; set; }


        public string ClaimNumber { get; set; }
        public DateTimeOffset NotificationDate { get; set;}
        public DateTimeOffset AccidentDate { get; set; }
        public DbGeography Location { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }


        public virtual PolicyPeriod PolicyPeriod { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
        public string LastModifiedReason { get; set; }


        public override string ToString()
        {
            return ClaimNumber + " - " + PolicyPeriod.Policy.PolicyNumber + " - " + PolicyPeriod.Policy.Vehicle.PalateNumber + ", " + AccidentDate.ToString("YYYY-MM-DD");
        }
    }
}
