using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBookingSystem.Data.ApplicationDbContext
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreatedEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Capacities = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PromotionalCode = table.Column<string>(nullable: true),
                    StudentNameber = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatedEvents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CreatedEventID = table.Column<int>(nullable: true),
                    StudentNumber = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Participations_CreatedEvents_CreatedEventID",
                        column: x => x.CreatedEventID,
                        principalTable: "CreatedEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participations_CreatedEventID",
                table: "Participations",
                column: "CreatedEventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "CreatedEvents");
        }
    }
}
