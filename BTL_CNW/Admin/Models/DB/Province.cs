namespace Admin.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Province")]
    public partial class Province : RowTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Province()
        {
            TourDestinations = new HashSet<TourDestination>();
        }

        [Key]
        [StringLength(10)]
        public string maTinh { get; set; }

        [Required]
        [StringLength(10)]
        public string maQG { get; set; }

        [StringLength(100)]
        public string tenTinh { get; set; }

        [StringLength(100)]
        public string pic { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        public virtual Nation Nation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TourDestination> TourDestinations { get; set; }
        public override string RowTable_TableType()
        {
            return "<th>" + this.maTinh + "<th>\n" +
                "<th>" + this.maQG + "<th>\n" +
                "<th>" + this.tenTinh + "<th>\n" +
                "<th>" + this.pic + "<th>\n" +
                "<th>" + this.note + "<th>\n"
                ;
        }
    }
}
