using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFactura.Models;

public partial class FacturaContext : DbContext
{
    public FacturaContext()
    {
    }

    public FacturaContext(DbContextOptions<FacturaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FacturaCabecera> FacturaCabeceras { get; set; }

    public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-J2SS3UU\\SQLEXPRESS;Database=Factura; Integrated security=true;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FacturaCabecera>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__FacturaC__5C02486500E5E773");

            entity.ToTable("FacturaCabecera");

            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.NumeroFactura).HasMaxLength(50);
            entity.Property(e => e.RazonSocial).HasMaxLength(100);
            entity.Property(e => e.Ruc).HasMaxLength(20);
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__FacturaD__6E19D6DA001657BC");

            entity.ToTable("FacturaDetalle");

            entity.Property(e => e.CodigoProducto).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Factura).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FacturaDe__Factu__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
