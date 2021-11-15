namespace plog_project.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class blogcontect : DbContext
    {
        public blogcontect()
            : base("name=blogcontect")
        {
        }

        public virtual DbSet<admeen> admeens { get; set; }
        public virtual DbSet<catalog> catalogs { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admeen>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<admeen>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<admeen>()
                .HasMany(e => e.news)
                .WithOptional(e => e.admeen)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<catalog>()
                .HasMany(e => e.news)
                .WithOptional(e => e.catalog)
                .HasForeignKey(e => e.cat_id);

            modelBuilder.Entity<news>()
                .Property(e => e.dec)
                .IsUnicode(false);
        }
    }
}
