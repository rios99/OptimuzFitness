using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc_optimuz.Migrations
{
    public partial class agregarPersonalSocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePersonal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoPersonal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSocio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoSocio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socio", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Socio");
        }
    }
}
