using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UmbaniApiTest.Migrations
{
    public partial class UmbaniDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    PersonUsername = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    MeasurementId = table.Column<Guid>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    Humidity = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Depth = table.Column<double>(nullable: false),
                    Lenght = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Catagory = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: true),
                    Pass = table.Column<bool>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.MeasurementId);
                    table.ForeignKey(
                        name: "FK_Measurement_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_PersonId",
                table: "Measurement",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
