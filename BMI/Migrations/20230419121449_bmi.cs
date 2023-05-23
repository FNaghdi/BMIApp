using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMIApp.Migrations
{
    /// <inheritdoc />
    public partial class bmi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IDperson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeMeli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IDperson);
                });

            migrationBuilder.CreateTable(
                name: "BMI",
                columns: table => new
                {
                    IDBmi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    bmi = table.Column<double>(type: "float", nullable: false),
                    Idpersons = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMI", x => x.IDBmi);
                    table.ForeignKey(
                        name: "FK_BMI_Person_Idpersons",
                        column: x => x.Idpersons,
                        principalTable: "Person",
                        principalColumn: "IDperson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BMI_Idpersons",
                table: "BMI",
                column: "Idpersons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BMI");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
