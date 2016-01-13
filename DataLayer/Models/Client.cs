using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public long ID { get; set; }
        [MaxLength(10), MinLength(10)]
        ///the first policy number
        public string ClientCode { get; set; }
        public bool IsLegalPerson { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public Person Person { get; set; }
        public LegalPerson LegalPerson { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
       

        public override string ToString()
        {
            return IsLegalPerson == true ? LegalPerson.ToString() : Person.ToString();
        }
    }
}
