namespace Admin.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nation")]
    public partial class Nation : RowTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nation()
        {
            Provinces = new HashSet<Province>();
        }

        [Key]
        [StringLength(10)]
        public string maQG { get; set; }

        [StringLength(100)]
        public string tenQG { get; set; }

        [StringLength(100)]
        public string pic { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Province> Provinces { get; set; }
        public override string RowTable_TableType()
        {
            return "<th>" + this.maQG + "<th>\n" +
                "<th>" + this.tenQG + "<th>\n" +
                "<th>" + this.pic + "<th>\n" +
                "<th>" + this.note + "<th>\n"
                ;
        }
    }
}
