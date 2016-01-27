using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("ClaimContact")]
    public class ClaimContact
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Email address"), DataType(DataType.EmailAddress), StringLength(100)]
        public string Email { get; set; }
        [Display(Name = "Phone number"), DataType(DataType.PhoneNumber), DisplayFormat(DataFormatString = "{0:(###) ##-#######}"), StringLength(25)]
        public string PhoneNumber { get; set; }


        [ForeignKey("Claim"), Required]
        public int Claim_ID { get; set; }


        public virtual Claim Claim { get; set; }
        public virtual ICollection<ClaimPicture> Pictures { get; set; }
    }
}
