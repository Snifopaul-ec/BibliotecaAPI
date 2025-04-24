using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acceso",
                columns: table => new
                {
                    id_acceso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    fecha_hora = table.Column<DateTime>(type: "datetime", nullable: false),
                    exito = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__acceso__F2593D4AD03FF1EB", x => x.id_acceso);
                });

            migrationBuilder.CreateTable(
                name: "auditoria",
                columns: table => new
                {
                    id_auditoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tabla_afectada = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    accion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    fecha_hora = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    json_detalle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__auditori__9644A3CEE167B8DC", x => x.id_auditoria);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    id_libro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    autor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    editorial = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    anio = table.Column<int>(type: "int", nullable: true),
                    isbn = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__libros__EC09C24E4F753B6C", x => x.id_libro);
                });

            migrationBuilder.CreateTable(
                name: "permisos",
                columns: table => new
                {
                    id_permiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_permiso = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__permisos__228F224F4B6C10E8", x => x.id_permiso);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    id_persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    apellidos = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    cedula = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__personas__228148B08F27E3D6", x => x.id_persona);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_rol = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__rol__6ABCB5E02D30439B", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    correo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    fecha_inscripcion = table.Column<DateOnly>(type: "date", nullable: true),
                    id_persona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usuarios__4E3E04ADD637C0C0", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK__usuarios__id_per__3C69FB99",
                        column: x => x.id_persona,
                        principalTable: "personas",
                        principalColumn: "id_persona");
                });

            migrationBuilder.CreateTable(
                name: "rol_has_permisos",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    id_permiso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__rol_has___889447C46F9B5DFE", x => new { x.id_rol, x.id_permiso });
                    table.ForeignKey(
                        name: "FK__rol_has_p__id_pe__47DBAE45",
                        column: x => x.id_permiso,
                        principalTable: "permisos",
                        principalColumn: "id_permiso");
                    table.ForeignKey(
                        name: "FK__rol_has_p__id_ro__46E78A0C",
                        column: x => x.id_rol,
                        principalTable: "rol",
                        principalColumn: "id_rol");
                });

            migrationBuilder.CreateTable(
                name: "usuario_has_rol",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usuario___5895CFF3018A5A66", x => new { x.id_usuario, x.id_rol });
                    table.ForeignKey(
                        name: "FK__usuario_h__id_ro__4222D4EF",
                        column: x => x.id_rol,
                        principalTable: "rol",
                        principalColumn: "id_rol");
                    table.ForeignKey(
                        name: "FK__usuario_h__id_us__412EB0B6",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__libros__99F9D0A4F5C24661",
                table: "libros",
                column: "isbn",
                unique: true,
                filter: "[isbn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__personas__415B7BE562FFEF3E",
                table: "personas",
                column: "cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rol_has_permisos_id_permiso",
                table: "rol_has_permisos",
                column: "id_permiso");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_has_rol_id_rol",
                table: "usuario_has_rol",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id_persona",
                table: "usuarios",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "UQ__usuarios__2A586E0BA440ACDF",
                table: "usuarios",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__usuarios__9AFF8FC6BC826AAA",
                table: "usuarios",
                column: "usuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acceso");

            migrationBuilder.DropTable(
                name: "auditoria");

            migrationBuilder.DropTable(
                name: "libros");

            migrationBuilder.DropTable(
                name: "rol_has_permisos");

            migrationBuilder.DropTable(
                name: "usuario_has_rol");

            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "personas");
        }
    }
}
