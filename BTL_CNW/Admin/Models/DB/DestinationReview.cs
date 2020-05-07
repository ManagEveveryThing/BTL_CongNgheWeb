namespace Admin.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DestinationReview")]
    public partial class DestinationReview :RowTable
    {
        [Key]
        [StringLength(10)]
        public string maDD { get; set; }

        [StringLength(100)]
        public string tenDD { get; set; }

        [StringLength(100)]
        public string tenTinh { get; set; }

        [StringLength(100)]
        public string tenQG { get; set; }

        [StringLength(100)]
        public string pic { get; set; }

        public override string RowTable_TableType()
        {
            return "<th>" + this.maDD + "<th>\n" +
                "<th>" + this.tenDD + "<th>\n" +
                "<th>" + this.tenTinh + "<th>\n" +
                "<th>" + this.tenQG + "<th>\n" +
                "<th>" + this.pic + "<th>\n"
                ;
        }
    }
}
