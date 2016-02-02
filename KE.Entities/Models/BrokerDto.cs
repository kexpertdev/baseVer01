using KE.Entities.Emuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Models
{
    public class BrokerDto
    {
        public int ID { get; set; }


        [Display(Name = "Name"), Required, StringLength(100, MinimumLength = 6, ErrorMessage = "The username must be at least 6 characters")]
        public string Name { get; set; }
        //[Display(Name = "Username"), Required, StringLength(50, MinimumLength = 6, ErrorMessage = "The username must be at least 6 characters")]
        //public string Username { get; set; }
        //[Display(Name = "Password"), Required, DataType(DataType.Password), StringLength(25, MinimumLength = 6, ErrorMessage = "The password must be at least 6 characters")]
        //public string Password { get; set; }
        [Display(Name = "Tax number"), Required, DisplayFormat(DataFormatString = "{0:########-#-###}")]
        public string TaxNumber { get; set; }
        [Display(Name = "Bank account number"), Required, DataType(DataType.CreditCard), DisplayFormat(DataFormatString = "{0:########-########-########}")]
        public string BankAccountNumber { get; set; }
        [Display(Name = "Email address"), DataType(DataType.EmailAddress), StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Phone number"), DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###) ##-#######}"), StringLength(25)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }


        public int Address_ID { get; set; }
        public int? MailingAddress_ID { get; set; }
        public int? CreatedBy_ID { get; set; }
        public int? ModifiedBy_ID { get; set; }


        [Display(Name = "Created at"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Modified at"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? Modified { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
        public string ModifiedReason { get; set; }
        //public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return String.Format("{0} - {1}, {2}", TaxNumber.ToString(), Name, IsActive ? Status.Active.ToString() : Status.Inactive.ToString());
        }
    }
}
