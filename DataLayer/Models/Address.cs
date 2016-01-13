using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int ID { get; set; }


        [MaxLength(4), MinLength(4)]
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }


        public override string ToString()
        {
            return PostalCode + ", " + City + " " + StreetName + " " + StreetNumber;
        }
    }
}
