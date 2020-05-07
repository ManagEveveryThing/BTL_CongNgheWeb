namespace Admin.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog: RowTable
    {
        [Key]
        [StringLength(10)]
        public string maBlog { get; set; }

        [Required]
        [StringLength(10)]
        public string maDD { get; set; }

        [StringLength(25)]
        public string username { get; set; }

        [StringLength(1000)]
        public string content { get; set; }

        [StringLength(500)]
        public string pic { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        public virtual TourDestination TourDestination { get; set; }

        public override string RowTable_TableType()
        {
            return "<th>" + this.maBlog + "<th>\n" +
                "<th>" + this.maDD + "<th>\n"+
                "<th>" + this.username + "<th>\n"+
                "<th>" + this.content + "<th>\n"+
                "<th>" + this.pic + "<th>\n" +
                "<th>" + this.note + "<th>\n"
                ;
        }
    }
}
