using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServidorMoviles.Models
{
    /*
     * CREADO AUTOMATICAMENTE CON
     * DB-SCAFFOLDING
     */
    public partial class DataContext : DbContext
    {
        public virtual DbSet<Bar> Bar { get; set; }
        public virtual DbSet<Tapa> Tapa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bar>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Lat)
                    .IsRequired()
                    .HasColumnName("lat");

                entity.Property(e => e.Lon)
                    .IsRequired()
                    .HasColumnName("lon");

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

            modelBuilder.Entity<Tapa>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.BarId).HasColumnName("barId");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

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

                entity.HasOne(d => d.Bar)
                    .WithMany(p => p.Tapa)
                    .HasForeignKey(d => d.BarId);
            });

            modelBuilder.Entity<Usuario>(entity =>
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
