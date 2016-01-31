
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
    [Table("InsuranceCompany")]
    public class InsuranceCompany
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
