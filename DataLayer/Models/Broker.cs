using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Broker")]
    public class Broker
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Name"), Required, StringLength(100, MinimumLength = 6, ErrorMessage = "The username must be at least 6 characters")]
        public string Name { get; set; }
        [Display(Name = "Username"), Required, StringLength(50, MinimumLength = 6, ErrorMessage = "The username must be at least 6 characters")]
        public string Username { get; set; }
        [Display(Name = "Password"), Required, DataType(DataType.Password), StringLength(25, MinimumLength = 6, ErrorMessage = "The password must be at least 6 characters")]
        public string Password { get; set; }
        [Display(Name = "Tax number"), Required, DisplayFormat(DataFormatString = "{0:########-#-###}")]
        public string TaxNumber { get; set; }
        [Display(Name = "Bank account number"), Required, DataType(DataType.CreditCard), DisplayFormat(DataFormatString = "{0:########-########-########}")]
        public string BankAccountNumber { get; set; }
        [Display(Name = "Email address"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Phone number"), DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###) ##-#######}")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }


        public virtual Address Address { get; set; }
        public virtual Address MailingAddress { get; set; }
        public virtual AppUser CreatedBy { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
        [Display(Name = "Modified date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedDate { get; set; }
        [Display(Name = "Modified reason")]
        public string ModifiedReason { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return TaxNumber + " - " + Name + ", " + IsActive.ToString();
        }
    }
}
