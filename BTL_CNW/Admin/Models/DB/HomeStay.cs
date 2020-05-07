namespace Admin.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HomeStay")]
    public partial class HomeStay : RowTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HomeStay()
        {
            DSKSCanTTs = new HashSet<DSKSCanTT>();
            DSKSTheoTrips = new HashSet<DSKSTheoTrip>();
            DSKSTrongWLs = new HashSet<DSKSTrongWL>();
        }

        [Key]
        [StringLength(10)]
        public string maKS { get; set; }

        [Required]
        [StringLength(10)]
        public string maDD { get; set; }

        [StringLength(50)]
        public string tenKS { get; set; }

        [StringLength(10)]
        public string phoneNum { get; set; }

        [StringLength(100)]
        public string pic { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSKSCanTT> DSKSCanTTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSKSTheoTrip> DSKSTheoTrips { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSKSTrongWL> DSKSTrongWLs { get; set; }

        public virtual TourDestination TourDestination { get; set; }

        public override string RowTable_TableType()
        {
            return "<th>" + this.maKS + "<th>\n" +
                "<th>" + this.maDD + "<th>\n" +
                "<th>" + this.tenKS + "<th>\n" +
                "<th>" + this.phoneNum + "<th>\n" +
                "<th>" + this.pic + "<th>\n" +
                "<th>" + this.note + "<th>\n"
                ;
        }
    }
}
