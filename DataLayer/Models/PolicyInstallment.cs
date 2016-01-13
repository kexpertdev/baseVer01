using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("PolicyInstallment")]
    public class PolicyInstallment
    {
        [Key]
        public long ID { get; set; }
        public int Nr { get; set; }
        public int Type { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public int Value { get; set; }
        public int IncomeValue { get; set; }
        public DateTimeOffset PayedDate { get; set; }
        public DateTimeOffset ChequeSentToPrint { get; set; }


        public PolicyPeriod PolicyPeriod { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
        public string LastModifiedReason { get; set; }


        public override string ToString()
        {
            return DueDate.ToString("YYYY-MM-DD") + " - " + Value.ToString();
        }
    }
}
