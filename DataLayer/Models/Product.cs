﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ID { get; set; }


        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
