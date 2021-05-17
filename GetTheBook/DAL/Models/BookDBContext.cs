using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GetTheBook.DAL.Models
{
    public partial class BookDBContext : DbContext
    {
        public BookDBContext()
        {
        }

        public BookDBContext(DbContextOptions<BookDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-088R6HE;Database=BookDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Authors)
                    .HasMaxLength(255)
                    .HasColumnName("authors");

                entity.Property(e => e.AverageRating)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("average_rating");

                entity.Property(e => e.Borrowed).HasColumnName("borrowed");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(10)
                    .HasColumnName("isbn");

                entity.Property(e => e.Isbn13)
                    .HasMaxLength(13)
                    .HasColumnName("isbn13");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(5)
                    .HasColumnName("language_code");

                entity.Property(e => e.NumPages).HasColumnName("num_pages");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("date")
                    .HasColumnName("publication_date");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(255)
                    .HasColumnName("publisher");

                entity.Property(e => e.RatingsCount).HasColumnName("ratings_count");

                entity.Property(e => e.TextReviewsCount).HasColumnName("text_reviews_count");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_books_users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
