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
    
    public partial class DSTripTheoTour
    {
        public string maCD { get; set; }
        public string maTour { get; set; }
        public string note { get; set; }
    
        public virtual Tour Tour { get; set; }
        public virtual Trip Trip { get; set; }
    }
}