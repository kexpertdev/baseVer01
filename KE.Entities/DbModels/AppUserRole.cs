using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
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


        public override string ToString()
        {
            return Name;
        }
    }
}
