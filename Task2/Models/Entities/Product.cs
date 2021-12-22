﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task2.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public Double Price { get; set; }
        [Required]
        public string Desc { get; set; }
    }
}