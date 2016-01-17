using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("PolicyModificationKeywords")]
    public class PolicyModificationKeywords
    {
        [Key]
        public int ID { get; set; }


        [Display(Name = "Keyword"), Required, StringLength(255)]
        public string Keyword { get; set; }
        [Display(Name = "Keyword group"), Required, StringLength(50)]
        public string KeywordGroup { get; set; }
        [Display(Name = "Keyword type"), Required, StringLength(50)]
        public string KeywordType { get; set; }


        public override string ToString()
        {
            return Keyword + " - " + KeywordGroup + " - " + KeywordType;
        }
    }
}
