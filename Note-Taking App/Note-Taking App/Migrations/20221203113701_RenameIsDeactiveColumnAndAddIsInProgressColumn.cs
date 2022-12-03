using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Note_Taking_App.Migrations
{
    public partial class RenameIsDeactiveColumnAndAddIsInProgressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeactive",
                table: "Notes",
                newName: "IsInProgress");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "IsInProgress",
                table: "Notes",
                newName: "IsDeactive");
        }
    }
}
