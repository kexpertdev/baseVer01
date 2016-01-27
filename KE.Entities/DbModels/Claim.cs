using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("Claim")]
    public class Claim : BaseModel
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Claim number"), Required, StringLength(10, MinimumLength = 10)]
        public string ClaimNumber { get; set; }
        [Display(Name = "Insurer claim number"), Required, StringLength(100)]
        public string InsurerClaimNumber { get; set; }
        [Display(Name = "Notification date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset NotificationDate { get; set;}
        [Display(Name = "Accident date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset AccidentDate { get; set; }
        [Display(Name = "Geography location")]
        public DbGeography Location { get; set; }
        [Display(Name = "Latitude")]
        public float Latitude { get; set; }
        [Display(Name = "Longitude")]
        public float Longitude { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Location description")]
        public string LocationDesc { get; set; }
        [Display(Name = "Insurer"), StringLength(25)]
        public string Insurer { get; set; }
        [Display(Name = "Insurer policy number"), StringLength(50)]
        public string InsurerPolicyNumber { get; set; }


        //ClaimInspector Data: Name, Tel


        [ForeignKey("PolicyPeriod"), Required]
        public long PolicyPeriod_ID { get; set; }
        [ForeignKey("CreatedBy")]
        public int CreatedBy_ID { get; set; }
        [ForeignKey("ModifiedBy")]
        public int? ModifiedBy_ID { get; set; }


        //public virtual ClaimContactPerson ClaimantA { get; set; }
        //public virtual ClaimContactPerson ClaimantB { get; set; }
        //public virtual ICollection<ClaimPicture> ClaimPictures { get; set; }
        public virtual ICollection<ClaimContact> Claimants { get; set; }
        public virtual PolicyPeriod PolicyPeriod { get; set; }
        public virtual AppUser CreatedBy { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return ClaimNumber + " - " + PolicyPeriod.Policy.PolicyNumber + " - " + PolicyPeriod.Policy.Vehicle.PalateNumber + ", " + AccidentDate.ToString("YYYY-MM-DD");
        }
    }
}
