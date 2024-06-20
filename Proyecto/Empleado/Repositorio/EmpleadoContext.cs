using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio;

public partial class EmpleadoContext : DbContext
{
    public EmpleadoContext()
    {
    }

    public EmpleadoContext(DbContextOptions<EmpleadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DOPEO9G\\SQLEXPRESS;Database=Empleados;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__C225F98D350CDD6D");

            entity.ToTable("Departamento");

            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__5295297C4688475F");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.FechaIngreso).HasColumnName("fechaIngreso");
            entity.Property(e => e.FechaNac).HasColumnName("fechaNac");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.IdGenero).HasColumnName("idGenero");
            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__idDepa__47DBAE45");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__idGene__48CFD27E");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__idPais__46E78A0C");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__Genero__85223DA3E6C67A7F");

            entity.ToTable("Genero");

            entity.Property(e => e.IdGenero).HasColumnName("idGenero");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__Pais__BD2285E3BFB93557");

            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
