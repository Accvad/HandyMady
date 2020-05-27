using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_proj_Backend.Data.Migrations
{
    public partial class HandyMadyMigrationExample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sale_name",
                table: "Goods",
                newName: "Good_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Good_name",
                table: "Goods",
                newName: "Sale_name");
        }
    }
}
