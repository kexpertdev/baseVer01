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


        public string IDCardNumber { get; set; }
        public string Title { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string BirthPlace { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string MotherLastName { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName { get; set; }


        public Address Address { get; set; }
        public Address MailingAddress { get; set; }


        [Display(Name = "FullName")]
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
