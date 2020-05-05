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
    
    public partial class Tour
    {
        public Tour()
        {
            this.DSTourCanTTs = new HashSet<DSTourCanTT>();
            this.DSTourTrongWLs = new HashSet<DSTourTrongWL>();
            this.DSTripTheoTours = new HashSet<DSTripTheoTour>();
        }
    
        public string maTour { get; set; }
        public string tenTour { get; set; }
        public Nullable<System.DateTime> dayStart { get; set; }
        public Nullable<int> soLuongMax { get; set; }
        public Nullable<int> soDem { get; set; }
        public string pic { get; set; }
        public string note { get; set; }
    
        public virtual ICollection<DSTourCanTT> DSTourCanTTs { get; set; }
        public virtual ICollection<DSTourTrongWL> DSTourTrongWLs { get; set; }
        public virtual ICollection<DSTripTheoTour> DSTripTheoTours { get; set; }
    }
}
