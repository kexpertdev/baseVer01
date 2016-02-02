using KE.Entities.Emuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("Broker")]
    public class Broker : BaseModel
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
        [Display(Name = "Email address"), DataType(DataType.EmailAddress), StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Phone number"), DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###) ##-#######}"), StringLength(25)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }


        [ForeignKey("Address")]
        public int Address_ID { get; set; }
        [ForeignKey("MailingAddress")]
        public int? MailingAddress_ID { get; set; }
        [ForeignKey("CreatedBy")]
        public int? CreatedBy_ID { get; set; }
        [ForeignKey("ModifiedBy")]
        public int? ModifiedBy_ID { get; set; }


        public virtual Address Address { get; set; }
        public virtual Address MailingAddress { get; set; }
        public virtual AppUser CreatedBy { get; set; }
        public virtual AppUser ModifiedBy { get; set; }
        //public virtual ICollection<AppUser> Users { get; set; }


        public override string ToString()
        {
            return String.Format("{0} - {1}, {2}", TaxNumber.ToString(), Name, IsActive ? Status.Active.ToString() : Status.Inactive.ToString());
        }
    }
}
