using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Palate number"), Required, StringLength(25)]
        public string PalateNumber { get; set; }
        [Display(Name = "VIN"), Required, StringLength(50)]
        public string VIN { get; set; }
        [Display(Name = "Registration certificate number"), Required, StringLength(25)]
        public string RegistrationCertificateNumber { get; set; }
        [Display(Name = "Make"), Required, StringLength(100)]
        public string Make { get; set; }
        [Display(Name = "Model"), Required, StringLength(100)]
        public string Model { get; set; }
        [Display(Name = "Type"), Required, StringLength(100)]
        public string Type { get; set; }
        [Display(Name = "Color"), StringLength(50)]
        public string Color { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
        [Display(Name = "Modified date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedDate { get; set; }
        [Display(Name = "Modified reason")]
        public string ModifiedReason { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return PalateNumber + ", " + VIN + ", " + RegistrationCertificateNumber;
        }
    }
}
