using Microsoft.EntityFrameworkCore.Migrations;

namespace noofs.SWRules.EntityFrameworkCore.Migrations
{
    public partial class Table_Powers_Add_Trappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Trappings",
                table: "Powers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Trappings",
                table: "Powers");
        }
    }
}
