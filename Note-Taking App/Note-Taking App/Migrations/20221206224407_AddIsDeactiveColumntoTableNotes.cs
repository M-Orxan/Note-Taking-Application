using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Note_Taking_App.Migrations
{
    public partial class AddIsDeactiveColumntoTableNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeactive",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeactive",
                table: "Notes");
        }
    }
}
