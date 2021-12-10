using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentBeheer.Migrations
{
    public partial class IntitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eind = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achternaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderID = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Inschrijvingen",
                columns: table => new
                {
                    InschrijvingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inschrijvingen", x => x.InschrijvingId);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inschrijvingen_Student_StudentId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_ModuleId",
                table: "Inschrijvingen",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inschrijvingen_StudentId",
                table: "Inschrijvingen",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Inschrijvingen");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
