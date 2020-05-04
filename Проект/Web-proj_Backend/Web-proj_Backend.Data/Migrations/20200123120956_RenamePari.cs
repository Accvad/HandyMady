using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_proj_Backend.Data.Migrations
{
    public partial class RenamePari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Paris",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Paris",
                newName: "IdUser");
        }
    }
}
