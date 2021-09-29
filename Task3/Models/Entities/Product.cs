using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task2.Models.Entities
{
    public class Product
    {
        internal static bool session;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public Double Price { get; set; }
        public string Desc { get; set; }
    }
}