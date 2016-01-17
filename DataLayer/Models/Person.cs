using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Title"), StringLength(50)]
        public string Title { get; set; }
        [Display(Name = "Last name"), Required, StringLength(100)]
        public string LastName { get; set; }
        [Display(Name = "First name"), Required, StringLength(100)]
        public string FirstName { get; set; }
        [Display(Name = "Middle name"), Required, StringLength(100)]
        public string MiddleName { get; set; }
        [Display(Name = "Birth place"), Required, StringLength(100)]
        public string BirthPlace { get; set; }
        [Display(Name = "Birth date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset BirthDate { get; set; }
        [Display(Name = "Mother last name"), Required, StringLength(100)]
        public string MotherLastName { get; set; }
        [Display(Name = "Mother first name"), Required, StringLength(100)]
        public string MotherFirstName { get; set; }
        [Display(Name = "Mother middle name"), Required, StringLength(100)]
        public string MotherMiddleName { get; set; }
        [Display(Name = "Gender"), Required, StringLength(10)]
        public string Gender { get; set; }
        [Display(Name = "Identity card number"), StringLength(25)]
        public string IdentityCardNumber { get; set; }


        public virtual Address Address { get; set; }
        public virtual Address MailingAddress { get; set; }


        [Display(Name = "Full name"), NotMapped]
        public string FullName
        {
            get
            {
                return (Title + " " + LastName + " " + FirstName + " " + MiddleName).Trim();
            }

        }


        public override string ToString()
        {
            return (FullName + ", " + BirthPlace + " " + BirthDate).Trim();
        }
    }
}
