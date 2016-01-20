using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("BaseLegalPerson")]
    public class LegalPerson
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Name"), Required, StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Tax number"), Required, DisplayFormat(DataFormatString = "{0:########-#-###}")]
        public string TaxNumber{ get; set; }


        public virtual Address Address { get; set; }
        public virtual Address MailingAddress { get; set; }


        public override string ToString()
        {
            return (TaxNumber + " - " + Name).Trim();
        }
    }
}
