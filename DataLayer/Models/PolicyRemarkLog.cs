using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("PolicyRemarkLog")]
    public class PolicyRemarkLog
    {
        [Key]
        public long ID { get; set; }
        public string Remark { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPushMessage { get; set; }
        public bool IsSentAsPushMessage { get; set; }

        public RemarkType RemarkType { get; set; }
        public virtual PolicyPeriod PolicyPeriod { get; set; }
        public AppUser CreatedBy { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
    }
}
