using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class MigracionPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
