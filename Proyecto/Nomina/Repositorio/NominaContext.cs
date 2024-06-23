using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nomina;

public partial class NominaContext : DbContext
{
    public NominaContext()
    {
    }

    public NominaContext(DbContextOptions<NominaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Antiguedad> Antiguedads { get; set; }

    public virtual DbSet<Compensacion> Compensacions { get; set; }

    public virtual DbSet<SalarioBase> SalarioBases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IMOD40G;Database=Nomina;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Antiguedad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Antiguedad");

            entity.Property(e => e.Anios).HasColumnName("anios");
            entity.Property(e => e.Bono)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("bono");
            entity.Property(e => e.IdAntiguedad)
                .ValueGeneratedOnAdd()
                .HasColumnName("idAntiguedad");
        });

        modelBuilder.Entity<Compensacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Compensacion");

            entity.Property(e => e.IdCompensacion)
                .ValueGeneratedOnAdd()
                .HasColumnName("idCompensacion");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.Multiplicador)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("multiplicador");
        });

        modelBuilder.Entity<SalarioBase>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SalarioBase");

            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.IdSalarioBase)
                .ValueGeneratedOnAdd()
                .HasColumnName("idSalarioBase");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
