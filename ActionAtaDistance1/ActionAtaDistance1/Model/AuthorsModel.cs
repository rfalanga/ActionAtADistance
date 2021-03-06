namespace ActionAtaDistance1.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AuthorsModel : DbContext
    {
        public AuthorsModel()
            : base("name=AuthorsContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<MysteryBook> MysteryBooks { get; set; }
        public virtual DbSet<MysteryGenre> MysteryGenres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.MysteryBooks)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MysteryGenre>()
                .HasMany(e => e.MysteryBooks)
                .WithRequired(e => e.MysteryGenre)
                .WillCascadeOnDelete(false);
        }
    }
}
