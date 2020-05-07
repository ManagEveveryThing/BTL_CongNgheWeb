namespace Admin.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer: RowTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            ElecBills = new HashSet<ElecBill>();
            WishLists = new HashSet<WishList>();
        }

        [Key]
        [StringLength(25)]
        public string username { get; set; }

        [StringLength(25)]
        public string pass { get; set; }

        [StringLength(25)]
        public string tenKH { get; set; }

        [StringLength(25)]
        public string hoKH { get; set; }

        [StringLength(10)]
        public string phoneNum { get; set; }

        [StringLength(25)]
        public string email { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ElecBill> ElecBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WishList> WishLists { get; set; }

        public override string RowTable_TableType()
        {
            return "<th>" + this.username + "<th>\n" +
                "<th>" + this.pass + "<th>\n" +
                "<th>" + this.tenKH + "<th>\n" +
                "<th>" + this.hoKH + "<th>\n" +
                "<th>" + this.phoneNum + "<th>\n" +
                "<th>" + this.email + "<th>\n"+
                "<th>" + this.note + "<th>\n"
                ;
        }
    }
}
