using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("ModificationReason")]
    public class ModificationReason
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
