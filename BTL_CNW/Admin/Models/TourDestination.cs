namespace Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourDestination")]
    public partial class TourDestination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TourDestination()
        {
            Blogs = new HashSet<Blog>();
            HomeStays = new HashSet<HomeStay>();
            Taxis = new HashSet<Taxi>();
            Trips = new HashSet<Trip>();
            Trips1 = new HashSet<Trip>();
        }

        [Key]
        [StringLength(10)]
        public string maDD { get; set; }

        [Required]
        [StringLength(10)]
        public string maTinh { get; set; }

        [StringLength(100)]
        public string tenDD { get; set; }

        [StringLength(100)]
        public string pic { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog> Blogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HomeStay> HomeStays { get; set; }

        public virtual Province Province { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Taxi> Taxis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trip> Trips { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trip> Trips1 { get; set; }
    }
}
