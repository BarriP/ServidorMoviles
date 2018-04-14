using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServidorMoviles.Models
{
    /**
     * Modelo generado automaticamente gracias al EF de Microsoft
     * Scaffold-DbContext "DataSource=J:\Visual Studio Workspace\ServidorMoviles\ServidorMoviles\wwwroot\DB\data.db" Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models
     */
    public partial class DataContext : DbContext
    {
        public virtual DbSet<Bares> Bares { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<Tapas> Tapas { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bares>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.Lon)
                    .HasColumnName("lon")
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.CommentTargetId).HasColumnName("commentTargetId");

                entity.Property(e => e.CommentType).HasColumnName("commentType");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Tapas>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PhotoUrl).HasColumnName("photoUrl");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");
            });
        }
    }
}
