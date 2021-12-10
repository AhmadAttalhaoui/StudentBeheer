using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentBeheer.Migrations
{
    public partial class SecondMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropColumn(
                name: "GenderID",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "GenderID",
                table: "Student",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gender_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gender_StudentId",
                table: "Gender",
                column: "StudentId",
                unique: true);
        }
    }
}
