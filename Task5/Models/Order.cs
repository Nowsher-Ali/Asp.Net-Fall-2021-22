//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.Orderdetails = new HashSet<Orderdetail>();
        }
    
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string status { get; set; }
        public int price { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
