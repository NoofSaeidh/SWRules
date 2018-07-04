using Microsoft.EntityFrameworkCore.Migrations;

namespace noofs.SWRules.EntityFrameworkCore.Migrations
{
    public partial class CreateTable_Powers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Distance = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    Points = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Powers");
        }
    }
}
