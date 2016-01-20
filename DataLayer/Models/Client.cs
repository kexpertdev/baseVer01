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


        ///the first policy number??
        [Display(Name = "Client code"), Required, MaxLength(10), MinLength(10)]
        public string ClientCode { get; set; }
        [Display(Name = "Is legal person"), Required]
        public bool IsLegalPerson { get; set; }
        [Display(Name = "Email address"), DataType(DataType.EmailAddress), StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Phone number"), DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###) ##-#######}"), StringLength(25)]
        public string PhoneNumber { get; set; }


        public virtual Person Person { get; set; }
        public virtual LegalPerson LegalPerson { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
        [Display(Name = "Modified date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedDate { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
        public string ModifiedReason { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return IsLegalPerson == true ? LegalPerson.ToString() : Person.ToString();
        }
    }
}
