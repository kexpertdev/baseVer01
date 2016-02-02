using KE.Entities.Emuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Models
{
    public class VehicleDto
    {
        public long ID { get; set; }

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
        [Display(Name = "Type"), Required]
        public VehicleTypes Type { get; set; }
        [Display(Name = "Usage"), Required]
        public VehicleUsages Usage { get; set; }
        [Display(Name = "Color"), StringLength(50)]
        public string Color { get; set; }


        public int? ModifiedBy_ID { get; set; }


        public override string ToString()
        {
            return PalateNumber + ", " + VIN + ", " + RegistrationCertificateNumber;
        }
    }
}
