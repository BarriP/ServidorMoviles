using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServidorMoviles.Models
{
    public partial class DataContext : DbContext
    {
        public virtual DbSet<Bar> Bar { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<ComentarioBar> ComentarioBar { get; set; }
        public virtual DbSet<ComentarioRuta> ComentarioRuta { get; set; }
        public virtual DbSet<ComentarioTapa> ComentarioTapa { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<Tapa> Tapa { get; set; }
        public virtual DbSet<TapasRuta> TapasRuta { get; set; }
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

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ComentarioBar>(entity =>
            {
                entity.HasKey(e => new { e.BarId, e.ComentarioId });

                entity.Property(e => e.BarId).HasColumnName("barId");

                entity.Property(e => e.ComentarioId).HasColumnName("comentarioId");

                entity.HasOne(d => d.Bar)
                    .WithMany(p => p.ComentarioBar)
                    .HasForeignKey(d => d.BarId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Comentario)
                    .WithMany(p => p.ComentarioBar)
                    .HasForeignKey(d => d.ComentarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ComentarioRuta>(entity =>
            {
                entity.HasKey(e => new { e.RutaId, e.ComentarioId });

                entity.Property(e => e.RutaId).HasColumnName("rutaId");

                entity.Property(e => e.ComentarioId).HasColumnName("comentarioId");

                entity.HasOne(d => d.Comentario)
                    .WithMany(p => p.ComentarioRuta)
                    .HasForeignKey(d => d.ComentarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.ComentarioRuta)
                    .HasForeignKey(d => d.RutaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ComentarioTapa>(entity =>
            {
                entity.HasKey(e => new { e.TapaId, e.ComentarioId });

                entity.Property(e => e.TapaId).HasColumnName("tapaId");

                entity.Property(e => e.ComentarioId).HasColumnName("comentarioId");

                entity.HasOne(d => d.Comentario)
                    .WithMany(p => p.ComentarioTapa)
                    .HasForeignKey(d => d.ComentarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tapa)
                    .WithMany(p => p.ComentarioTapa)
                    .HasForeignKey(d => d.TapaId)
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

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ruta)
                    .HasForeignKey(d => d.UserId);
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

            modelBuilder.Entity<TapasRuta>(entity =>
            {
                entity.HasKey(e => new { e.RutaId, e.TapaId });

                entity.Property(e => e.RutaId).HasColumnName("rutaId");

                entity.Property(e => e.TapaId).HasColumnName("tapaId");

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.TapasRuta)
                    .HasForeignKey(d => d.RutaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tapa)
                    .WithMany(p => p.TapasRuta)
                    .HasForeignKey(d => d.TapaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
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
