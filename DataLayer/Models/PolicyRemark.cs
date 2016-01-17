using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("PolicyRemark")]
    public class PolicyRemark
    {
        [Key]
        public long ID { get; set; }


        [Display(Name = "Remark"), Required]
        public string Remark { get; set; }
        [Display(Name = "Is private remark"), Required]
        public bool IsPrivate { get; set; }
        [Display(Name = "Is approved"), Required]
        public bool IsApproved { get; set; }
        [Display(Name = "Is push message"), Required]
        public bool IsPushMessage { get; set; }
        [Display(Name = "Is sent"), Required]
        public bool IsSentAsPushMessage { get; set; }


        public PolicyRemarkType RemarkType { get; set; }
        public virtual PolicyPeriod PolicyPeriod { get; set; }
        public AppUser CreatedBy { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }

        public override string ToString()
        {
            return Remark + ", " + CreatedDate.ToString();
        }
    }
}
