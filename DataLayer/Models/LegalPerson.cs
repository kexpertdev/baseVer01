using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("LegalPerson")]
    public class LegalPerson
    {
        [Key]
        public int ID { get; set; }


        public string Name { get; set; }
        public string TaxNumber{ get; set; }


        public Address Address { get; set; }
        public Address MailingAddress { get; set; }


        public override string ToString()
        {
            return (TaxNumber + " - " + Name).Trim();
        }
    }
}
