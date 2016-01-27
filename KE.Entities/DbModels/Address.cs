using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("BaseAddress")]
    public class Address
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Postal code"), Required, MaxLength(4), MinLength(4)]
        public string PostalCode { get; set; }
        [Display(Name = "City"), Required, StringLength(100)]
        public string City { get; set; }
         [Display(Name = "Street name"), Required, StringLength(100)]
        public string StreetName { get; set; }
         [Display(Name = "Street number"), Required, StringLength(25)]
        public string StreetNumber { get; set; }


        public override string ToString()
        {
            return PostalCode + ", " + City + " " + StreetName + " " + StreetNumber;
        }
    }
}
