using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("ClaimPictureType")]
    public class ClaimPictureType
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Type name"), Required, StringLength(100)]
        public string Name { get; set; }
    }
}
