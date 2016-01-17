using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("AppUserRole")]
    public class AppUserRole
    {
        [Key]
        public int ID { get; set; }


        [Required, StringLength(50, MinimumLength=4)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }


        [Display(Name = "Created date"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
