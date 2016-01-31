using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Entities.DbModels
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Created = DateTime.Now;
        }


        [Display(Name = "Modified at"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? Modified { get; set; }
        [Display(Name = "Modified reason"), StringLength(255)]
        public string ModifiedReason { get; set; }
        [Display(Name = "Created at"), Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //ApplyFormatInEditMode = true
        public DateTimeOffset Created { get; set; }


        public override string ToString()
        {
            return Created.ToString();
        }
    }
}
