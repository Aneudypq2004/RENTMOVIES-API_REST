using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EdadRecomendada = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CATEGORI__A3C02A108EFB586C", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "COSTO",
                columns: table => new
                {
                    IdCosto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__COSTO__D5D3CEA3CFCCE220", x => x.IdCosto);
                });

            migrationBuilder.CreateTable(
                name: "DIRECCION",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DireccionMunicipio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DireccionSector = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DireccionCalle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DireccionNumeroCasa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DIRECCIO__1F8E0C7614F2BA2C", x => x.IdDireccion);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ROLES__3214EC0757B102B7", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PELICULA",
                columns: table => new
                {
                    IdPeli = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Categoria_Id = table.Column<int>(type: "int", nullable: true),
                    CostoRenta_Id = table.Column<int>(type: "int", nullable: true),
                    isDisponible = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PELICULA__FD82E727B3EF8C8D", x => x.IdPeli);
                    table.ForeignKey(
                        name: "FK__PELICULA__Catego__440B1D61",
                        column: x => x.Categoria_Id,
                        principalTable: "CATEGORIA",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK__PELICULA__CostoR__44FF419A",
                        column: x => x.CostoRenta_Id,
                        principalTable: "COSTO",
                        principalColumn: "IdCosto");
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    FechaNac = table.Column<DateTime>(type: "datetime", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Token = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Verificado = table.Column<bool>(type: "bit", nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Direccion_Id = table.Column<int>(type: "int", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIO__3214EC0756AA15CA", x => x.Id);
                    table.ForeignKey(
                        name: "FK__USUARIO__Direcci__3C69FB99",
                        column: x => x.Direccion_Id,
                        principalTable: "DIRECCION",
                        principalColumn: "IdDireccion");
                    table.ForeignKey(
                        name: "FK__USUARIO__roleId__3B75D760",
                        column: x => x.roleId,
                        principalTable: "ROLES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ALQUILER",
                columns: table => new
                {
                    IdAlquiler = table.Column<int>(type: "int", nullable: false),
                    Usuario_Id = table.Column<int>(type: "int", nullable: true),
                    Pelicula_Id = table.Column<int>(type: "int", nullable: true),
                    FechaAlquiler = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ALQUILER__CB9A46B7D8452564", x => x.IdAlquiler);
                    table.ForeignKey(
                        name: "FK__ALQUILER__Pelicu__48CFD27E",
                        column: x => x.Pelicula_Id,
                        principalTable: "PELICULA",
                        principalColumn: "IdPeli");
                    table.ForeignKey(
                        name: "FK__ALQUILER__Usuari__47DBAE45",
                        column: x => x.Usuario_Id,
                        principalTable: "USUARIO",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALQUILER_Pelicula_Id",
                table: "ALQUILER",
                column: "Pelicula_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ALQUILER_Usuario_Id",
                table: "ALQUILER",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PELICULA_Categoria_Id",
                table: "PELICULA",
                column: "Categoria_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PELICULA_CostoRenta_Id",
                table: "PELICULA",
                column: "CostoRenta_Id");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_Direccion_Id",
                table: "USUARIO",
                column: "Direccion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_roleId",
                table: "USUARIO",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "UQ_USERNAME",
                table: "USUARIO",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALQUILER");

            migrationBuilder.DropTable(
                name: "PELICULA");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "COSTO");

            migrationBuilder.DropTable(
                name: "DIRECCION");

            migrationBuilder.DropTable(
                name: "ROLES");
        }
    }
}
