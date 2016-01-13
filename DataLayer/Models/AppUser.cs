using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("AppUser")]
    public class AppUser
    {
        [Key]
        public int ID { get; set; }


        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }


        public AppUserRole Role { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
        public string LastModifiedReason { get; set; }


        public override string ToString()
        {
            return Username + ", " + Email + ", " + IsActive.ToString();
        }
    }
}
