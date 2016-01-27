using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("Client")]
    public class Client : BaseModel
    {
        [Key]
        public long ID { get; set; }


        ///the first policy number??
        [Display(Name = "Client code"), Required, MaxLength(10), MinLength(10)]
        public string ClientCode { get; set; }
        [Display(Name = "Client code from broker"), MaxLength(100)]
        public string ClientCodeFromBroker { get; set; }
        [Display(Name = "Is legal person"), Required]
        public bool IsLegalPerson { get; set; }
        [Display(Name = "Email address"), DataType(DataType.EmailAddress), StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Phone number"), DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###) ##-#######}"), StringLength(25)]
        public string PhoneNumber { get; set; }


        [ForeignKey("Person")]
        public int? Person_ID { get; set; }
        [ForeignKey("LegalPerson")]
        public int? LegalPerson_ID { get; set; }
        [ForeignKey("ModifiedBy")]
        public int? ModifiedBy_ID { get; set; }


        public virtual Person Person { get; set; }
        public virtual LegalPerson LegalPerson { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return IsLegalPerson == true ? LegalPerson.ToString() : Person.ToString();
        }
    }
}
