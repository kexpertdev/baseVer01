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
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Name"), Required, StringLength(50)]
        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
