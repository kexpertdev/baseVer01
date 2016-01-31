using KE.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("InsurancePolicy")]
    public class InsurancePolicy
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Insurance company")]
        public int Company { get; set; }
        [Display(Name = "Insurance policy number"), StringLength(50)]
        public string PolicyNumber { get; set; }
        [Display(Name = "Insurance start date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset StartDate { get; set; }
        [Display(Name = "Insurance end date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset EndDate { get; set; }

        
        [ForeignKey("PolicyPeriod"), Required]
        public long PolicyPeriod_ID { get; set; }


        public virtual PolicyPeriod PolicyPeriod { get; set; }


        public override string ToString()
        {
            return Company + " " + PolicyNumber;
        }
    }
}
