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


        public string PalateNumber { get; set; }
        public string VIN { get; set; }
        public string RegistrationCertNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
      

        public override string ToString()
        {
            return PalateNumber + ", " + VIN + ", " + RegistrationCertNumber;
        }
    }
}
