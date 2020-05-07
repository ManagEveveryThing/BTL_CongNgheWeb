namespace Admin.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour : RowTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            DSTourCanTTs = new HashSet<DSTourCanTT>();
            DSTourTrongWLs = new HashSet<DSTourTrongWL>();
            DSTripTheoTours = new HashSet<DSTripTheoTour>();
        }

        [Key]
        [StringLength(10)]
        public string maTour { get; set; }

        [StringLength(50)]
        public string tenTour { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dayStart { get; set; }

        public int? soLuongMax { get; set; }

        public int? soDem { get; set; }

        [StringLength(100)]
        public string pic { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSTourCanTT> DSTourCanTTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSTourTrongWL> DSTourTrongWLs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSTripTheoTour> DSTripTheoTours { get; set; }
        public override string RowTable_TableType()
        {
            return "<th>" + this.maTour + "<th>\n" +
                "<th>" + this.tenTour + "<th>\n" +
                "<th>" + this.dayStart + "<th>\n" +
                "<th>" + this.soLuongMax + "<th>\n" +
                "<th>" + this.soDem + "<th>\n" +
                "<th>" + this.pic + "<th>\n" +
                "<th>" + this.note + "<th>\n"
                ;
        }
    }
}
