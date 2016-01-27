using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
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


        [ForeignKey("RemarkType")]
        public int RemarkType_ID { get; set; }
        [ForeignKey("PolicyPeriod")]
        public long PolicyPeriod_ID { get; set; }
        [ForeignKey("CreatedBy")]
        public int CreatedBy_ID { get; set; }


        public PolicyRemarkType RemarkType { get; set; }
        public virtual PolicyPeriod PolicyPeriod { get; set; }
        public AppUser CreatedBy { get; set; }


        [Display(Name = "Created at"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset Created { get; set; }


        public override string ToString()
        {
            return Remark + ", " + Created.ToString();
        }
    }
}
