//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DSKSTheoTrip
    {
        public string maCD { get; set; }
        public string maKS { get; set; }
        public string note { get; set; }
    
        public virtual HomeStay HomeStay { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
