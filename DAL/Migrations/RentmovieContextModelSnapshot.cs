﻿// <auto-generated />
using System;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(RentmovieContext))]
    partial class RentmovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ENTIDADES.Models.Alquiler", b =>
                {
                    b.Property<int>("IdAlquiler")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaAlquiler")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("datetime");

                    b.Property<int?>("PeliculaId")
                        .HasColumnType("int")
                        .HasColumnName("Pelicula_Id");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("Usuario_Id");

                    b.HasKey("IdAlquiler")
                        .HasName("PK__ALQUILER__CB9A46B7D8452564");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ALQUILER", (string)null);
                });

            modelBuilder.Entity("ENTIDADES.Models.Categorium", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Categoria")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("EdadRecomendada")
                        .HasColumnType("int");

                    b.HasKey("IdCategoria")
                        .HasName("PK__CATEGORI__A3C02A108EFB586C");

                    b.ToTable("CATEGORIA", (string)null);
                });

            modelBuilder.Entity("ENTIDADES.Models.Costo", b =>
                {
                    b.Property<int>("IdCosto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCosto"));

                    b.Property<int?>("Precio")
                        .HasColumnType("int");

                    b.HasKey("IdCosto")
                        .HasName("PK__COSTO__D5D3CEA3CFCCE220");

                    b.ToTable("COSTO", (string)null);
                });

            modelBuilder.Entity("ENTIDADES.Models.Direccion", b =>
                {
                    b.Property<int>("IdDireccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDireccion"));

                    b.Property<string>("DireccionCalle")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DireccionMunicipio")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DireccionNumeroCasa")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DireccionSector")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdDireccion")
                        .HasName("PK__DIRECCIO__1F8E0C7614F2BA2C");

                    b.ToTable("DIRECCION", (string)null);
                });

            modelBuilder.Entity("ENTIDADES.Models.Pelicula", b =>
                {
                    b.Property<int>("IdPeli")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPeli"));

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("Categoria_Id");

                    b.Property<int?>("CostoRentaId")
                        .HasColumnType("int")
                        .HasColumnName("CostoRenta_Id");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IsDisponible")
                        .HasColumnType("int")
                        .HasColumnName("isDisponible");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdPeli")
                        .HasName("PK__PELICULA__FD82E727B3EF8C8D");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("CostoRentaId");

                    b.ToTable("PELICULA", (string)null);
                });

            modelBuilder.Entity("ENTIDADES.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Admin")
                        .HasColumnType("bit")
                        .HasColumnName("admin");

                    b.HasKey("Id")
                        .HasName("PK__ROLES__3214EC0757B102B7");

                    b.ToTable("ROLES", (string)null);
                });

            modelBuilder.Entity("ENTIDADES.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Contraseña")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("DireccionId")
                        .HasColumnType("int")
                        .HasColumnName("Direccion_Id");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("FechaNac")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("roleId");

                    b.Property<string>("Token")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Verificado")
                        .HasColumnType("bit");

                    b.HasKey("Id")
                        .HasName("PK__USUARIO__3214EC0756AA15CA");

                    b.HasIndex("DireccionId");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "UserName" }, "UQ_USERNAME")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("ENTIDADES.Models.Alquiler", b =>
                {
                    b.HasOne("ENTIDADES.Models.Pelicula", "Pelicula")
                        .WithMany("Alquilers")
                        .HasForeignKey("PeliculaId")
                        .HasConstraintName("FK__ALQUILER__Pelicu__48CFD27E");

                    b.HasOne("ENTIDADES.Models.Usuario", "Usuario")
                        .WithMany("Alquilers")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK__ALQUILER__Usuari__47DBAE45");

                    b.Navigation("Pelicula");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ENTIDADES.Models.Pelicula", b =>
                {
                    b.HasOne("ENTIDADES.Models.Categorium", "Categoria")
                        .WithMany("Peliculas")
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("FK__PELICULA__Catego__440B1D61");

                    b.HasOne("ENTIDADES.Models.Costo", "CostoRenta")
                        .WithMany("Peliculas")
                        .HasForeignKey("CostoRentaId")
                        .HasConstraintName("FK__PELICULA__CostoR__44FF419A");

                    b.Navigation("Categoria");

                    b.Navigation("CostoRenta");
                });

            modelBuilder.Entity("ENTIDADES.Models.Usuario", b =>
                {
                    b.HasOne("ENTIDADES.Models.Direccion", "Direccion")
                        .WithMany("Usuarios")
                        .HasForeignKey("DireccionId")
                        .HasConstraintName("FK__USUARIO__Direcci__3C69FB99");

                    b.HasOne("ENTIDADES.Models.Role", "Role")
                        .WithMany("Usuarios")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__USUARIO__roleId__3B75D760");

                    b.Navigation("Direccion");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ENTIDADES.Models.Categorium", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("ENTIDADES.Models.Costo", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("ENTIDADES.Models.Direccion", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ENTIDADES.Models.Pelicula", b =>
                {
                    b.Navigation("Alquilers");
                });

            modelBuilder.Entity("ENTIDADES.Models.Role", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ENTIDADES.Models.Usuario", b =>
                {
                    b.Navigation("Alquilers");
                });
#pragma warning restore 612, 618
        }
    }
}
