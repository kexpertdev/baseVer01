using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("AppUser")]
    public class AppUser : BaseModel
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Fullname"), Required, StringLength(100, MinimumLength = 5, ErrorMessage = "The fullname must be at least 5 characters")]
        public string Fullname { get; set; }
        [Display(Name = "Username"), Required, StringLength(25, MinimumLength = 5, ErrorMessage = "The username must be at least 5 characters")]
        public string Username { get; set; }
        [Display(Name = "Password"), Required, DataType(DataType.Password), StringLength(25, MinimumLength=5, ErrorMessage="The password must be at least 5 characters")]
        public string Password { get; set; }   
        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }
        [Display(Name = "Email address"), DataType(DataType.EmailAddress), StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Phone number"), DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###) ##-#######}"), StringLength(25)]
        public string PhoneNumber { get; set; }


        //[ForeignKey("Broker"), Required]
        //public int Broker_ID { get; set; }
        [ForeignKey("Role"), Required]
        public int Role_ID { get; set; }
        [ForeignKey("CreatedBy")]
        public int? CreatedBy_ID { get; set; }
        [ForeignKey("ModifiedBy")]
        public int? ModifiedBy_ID { get; set; }


        //public virtual Broker Broker { get; set; }
        public virtual AppUserRole Role { get; set; }
        public virtual AppUser CreatedBy { get; set; }
        public virtual AppUser ModifiedBy { get; set; }


        public override string ToString()
        {
            return Username + ", " + Email + ", " + IsActive.ToString();
        }
    }
}
