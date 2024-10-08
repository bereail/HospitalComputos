using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace computosApp.Models.DB
{
    public partial class HospitalComputosContext : DbContext
    {
        public HospitalComputosContext()
        {
        }

        public HospitalComputosContext(DbContextOptions<HospitalComputosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Computadora> Computadoras { get; set; } = null!;
        public virtual DbSet<EntregaToner> EntregaToners { get; set; } = null!;
        public virtual DbSet<Impresora> Impresoras { get; set; } = null!;
        public virtual DbSet<Reparacione> Reparaciones { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<Toner> Toners { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=INF-SEC-001;Database=HospitalComputos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computadora>(entity =>
            {
                entity.HasKey(e => e.IdComputadora)
                    .HasName("PK__Computad__1102CC84094D511E");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("IP");

                entity.Property(e => e.NombrePc)
                    .HasMaxLength(255)
                    .HasColumnName("NombrePC");

                entity.Property(e => e.NombreUsuario).HasMaxLength(255);

                entity.Property(e => e.Usuario).HasMaxLength(255);

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Computadoras)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Computado__IdSer__693CA210");
            });

            modelBuilder.Entity<EntregaToner>(entity =>
            {
                entity.HasKey(e => e.IdEntregaToner)
                    .HasName("PK__EntregaT__D2D3856D62C9E55F");

                entity.ToTable("EntregaToner");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.EntregaToners)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK__EntregaTo__IdSer__6EF57B66");

                entity.HasOne(d => d.IdTonerNavigation)
                    .WithMany(p => p.EntregaToners)
                    .HasForeignKey(d => d.IdToner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EntregaTo__IdTon__6E01572D");
            });

            modelBuilder.Entity<Impresora>(entity =>
            {
                entity.HasKey(e => e.IdImpresora)
                    .HasName("PK__Impresor__627CBB0C44EB7FF2");

                entity.Property(e => e.NombreImpresora).HasMaxLength(255);

                entity.HasOne(d => d.IdComputadoraNavigation)
                    .WithMany(p => p.Impresoras)
                    .HasForeignKey(d => d.IdComputadora)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Impresora__IdCom__71D1E811");

                entity.HasOne(d => d.IdTonerNavigation)
                    .WithMany(p => p.Impresoras)
                    .HasForeignKey(d => d.IdToner)
                    .HasConstraintName("FK__Impresora__IdTon__72C60C4A");
            });

            modelBuilder.Entity<Reparacione>(entity =>
            {
                entity.HasKey(e => e.IdReparacion)
                    .HasName("PK__Reparaci__DCF37F00CECD80DF");

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdComputadoraNavigation)
                    .WithMany(p => p.Reparaciones)
                    .HasForeignKey(d => d.IdComputadora)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reparacio__IdCom__75A278F5");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__Servicio__2DCCF9A2EBB6A747");

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.NombreServicio).HasMaxLength(255);
            });

            modelBuilder.Entity<Toner>(entity =>
            {
                entity.HasKey(e => e.IdToner)
                    .HasName("PK__Toner__D6F13E8168B03651");

                entity.ToTable("Toner");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
