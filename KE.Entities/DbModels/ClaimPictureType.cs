using KE.Entities.Emuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    [Table("ClaimPictureType")]
    public class ClaimPictureType
    {
        [Key]
        public ClaimImageSetTypes ID { get; set; }

        [Display(Name = "Type name"), Required, StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Description"), Required, StringLength(255)]
        public string Description { get; set; }
    }
}
