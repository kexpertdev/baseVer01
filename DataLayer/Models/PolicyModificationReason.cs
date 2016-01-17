using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("PolicyModificationReason")]
    public class PolicyModificationReason
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Name"), Required, StringLength(100)]
        public string Name { get; set; }
    }
}
