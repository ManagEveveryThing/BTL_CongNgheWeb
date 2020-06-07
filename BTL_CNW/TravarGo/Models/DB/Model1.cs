namespace TravarGo.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model13")
        {
        }

        public virtual DbSet<DestinationTour> DestinationTours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DestinationTour>()
                .Property(e => e.maDD)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}