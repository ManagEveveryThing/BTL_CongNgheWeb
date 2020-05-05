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
    
    public partial class Trip
    {
        public Trip()
        {
            this.DSKSTheoTrips = new HashSet<DSKSTheoTrip>();
            this.DSTripTheoTours = new HashSet<DSTripTheoTour>();
        }
    
        public string maCD { get; set; }
        public string maDDStart { get; set; }
        public string maDDEnd { get; set; }
        public Nullable<System.DateTime> dayStrat { get; set; }
        public string pic { get; set; }
        public string note { get; set; }
    
        public virtual ICollection<DSKSTheoTrip> DSKSTheoTrips { get; set; }
        public virtual ICollection<DSTripTheoTour> DSTripTheoTours { get; set; }
        public virtual TourDestination TourDestination { get; set; }
        public virtual TourDestination TourDestination1 { get; set; }
    }
}
