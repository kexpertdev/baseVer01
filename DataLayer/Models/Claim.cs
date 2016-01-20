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

        [Display(Name = "Claim number"), Required, StringLength(10, MinimumLength = 10)]
        public string ClaimNumber { get; set; }
        [Display(Name = "Notification date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset NotificationDate { get; set;}
        [Display(Name = "Accident date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset AccidentDate { get; set; }
        [Display(Name = "Geography location")]
        public DbGeography Location { get; set; }
        [Display(Name = "Latitude")]
        public float Latitude { get; set; }
        [Display(Name = "Longitude")]
        public float Longitude { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }


        //public virtual ClaimContactPerson ClaimantA { get; set; }
        //public virtual ClaimContactPerson ClaimantB { get; set; }
        public virtual PolicyPeriod PolicyPeriod { get; set; }
        public virtual ICollection<ClaimPicture> ClaimPictures { get; set; }
        public virtual ICollection<ClaimContactPerson> Claimants { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
        [Display(Name = "Modified date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedDate { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
        public string ModifiedReason { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return ClaimNumber + " - " + PolicyPeriod.Policy.PolicyNumber + " - " + PolicyPeriod.Policy.Vehicle.PalateNumber + ", " + AccidentDate.ToString("YYYY-MM-DD");
        }
    }
}
