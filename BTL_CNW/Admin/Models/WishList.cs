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
    
    public partial class WishList
    {
        public WishList()
        {
            this.DSKSTrongWLs = new HashSet<DSKSTrongWL>();
            this.DSTourTrongWLs = new HashSet<DSTourTrongWL>();
        }
    
        public string maWL { get; set; }
        public string username { get; set; }
        public string note { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<DSKSTrongWL> DSKSTrongWLs { get; set; }
        public virtual ICollection<DSTourTrongWL> DSTourTrongWLs { get; set; }
    }
}
