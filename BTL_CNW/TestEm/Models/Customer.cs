//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestEm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.ElecBills = new HashSet<ElecBill>();
            this.WishLists = new HashSet<WishList>();
        }
    
        public string username { get; set; }
        public string pass { get; set; }
        public string tenKH { get; set; }
        public string hoKH { get; set; }
        public string phoneNum { get; set; }
        public string email { get; set; }
        public string note { get; set; }
    
        public virtual ICollection<ElecBill> ElecBills { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
