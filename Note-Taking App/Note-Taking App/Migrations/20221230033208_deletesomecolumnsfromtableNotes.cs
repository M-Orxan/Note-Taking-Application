using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Note_Taking_App.Migrations
{
    public partial class deletesomecolumnsfromtableNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IsInProgress",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInProgress",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
