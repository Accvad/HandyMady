using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_proj_Backend.Data.Migrations
{
    public partial class AddPariAndUsersMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Paris",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Paris");
        }
    }
}
