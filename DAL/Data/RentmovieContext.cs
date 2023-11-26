using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ENTIDADES.Models;

namespace DAL.Data;

public partial class RentmovieContext : DbContext
{
    public RentmovieContext()
    {
    }

    public RentmovieContext(DbContextOptions<RentmovieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alquiler> Alquilers { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Costo> Costos { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alquiler>(entity =>
        {
            entity.HasKey(e => e.IdAlquiler).HasName("PK__ALQUILER__CB9A46B7D8452564");

            entity.ToTable("ALQUILER");

            entity.Property(e => e.IdAlquiler).ValueGeneratedNever();
            entity.Property(e => e.FechaAlquiler).HasColumnType("datetime");
            entity.Property(e => e.FechaDevolucion).HasColumnType("datetime");
            entity.Property(e => e.PeliculaId).HasColumnName("Pelicula_Id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

            entity.HasOne(d => d.Pelicula).WithMany(p => p.Alquilers)
                .HasForeignKey(d => d.PeliculaId)
                .HasConstraintName("FK__ALQUILER__Pelicu__48CFD27E");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Alquilers)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__ALQUILER__Usuari__47DBAE45");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__A3C02A108EFB586C");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.Categoria)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Costo>(entity =>
        {
            entity.HasKey(e => e.IdCosto).HasName("PK__COSTO__D5D3CEA3CFCCE220");

            entity.ToTable("COSTO");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__DIRECCIO__1F8E0C7614F2BA2C");

            entity.ToTable("DIRECCION");

            entity.Property(e => e.DireccionCalle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionMunicipio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionNumeroCasa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionSector)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPeli).HasName("PK__PELICULA__FD82E727B3EF8C8D");

            entity.ToTable("PELICULA");

            entity.Property(e => e.CategoriaId).HasColumnName("Categoria_Id");
            entity.Property(e => e.CostoRentaId).HasColumnName("CostoRenta_Id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDisponible).HasColumnName("isDisponible");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__PELICULA__Catego__440B1D61");

            entity.HasOne(d => d.CostoRenta).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.CostoRentaId)
                .HasConstraintName("FK__PELICULA__CostoR__44FF419A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROLES__3214EC0757B102B7");

            entity.ToTable("ROLES");

            entity.Property(e => e.Admin).HasColumnName("admin");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USUARIO__3214EC0756AA15CA");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.UserName, "UQ_USERNAME").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DireccionId).HasColumnName("Direccion_Id");
            entity.Property(e => e.FechaNac).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
			entity.Property(e => e.Email).HasMaxLength(255);
			entity.Property(e => e.Token).HasMaxLength(255);
			entity.Property(e => e.Verificado)
			.IsUnicode(false)
            .HasMaxLength(2);
			entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Direccion).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.DireccionId)
                .HasConstraintName("FK__USUARIO__Direcci__3C69FB99");

            entity.HasOne(d => d.Role).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__USUARIO__roleId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
