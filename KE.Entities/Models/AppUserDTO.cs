using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.Models
{
    public class AppUserDto
    {
        public int ID { get; set; }


        [Display(Name = "Fullname"), Required, StringLength(100, MinimumLength = 6, ErrorMessage = "The fullname must be at least 6 characters")]
        public string Fullname { get; set; }
        [Display(Name = "Username"), Required, StringLength(25, MinimumLength = 6, ErrorMessage = "The username must be at least 6 characters")]
        public string Username { get; set; }
        [Display(Name = "Password"), Required, DataType(DataType.Password), StringLength(25, MinimumLength = 6, ErrorMessage = "The password must be at least 6 characters")]
        public string Password { get; set; }
        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }
        [Display(Name = "Email address"), DataType(DataType.EmailAddress), StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Phone number"), DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###) ##-#######}"), StringLength(25)]
        public string PhoneNumber { get; set; }


        public int Role_ID { get; set; }
        public int CreatedBy_ID { get; set; }
        public int? ModifiedBy_ID { get; set; }


        [Display(Name = "Created at"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Created { get; set; }
        [Display(Name = "Modified at"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? Modified { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
        public string ModifiedReason { get; set; }


        public override string ToString()
        {
            return "[" + ID + "] " + Username + ", " + Email + ", " + IsActive.ToString();
        }
    }
}
