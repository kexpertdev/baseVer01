using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("PolicyQuote")]
    public class PolicyQuote
    {
        [Key]
        public int ID { get; set; }


        public string Uid { get; set; }


        public DateTimeOffset CreatedDate { get; set; }
    }
}
