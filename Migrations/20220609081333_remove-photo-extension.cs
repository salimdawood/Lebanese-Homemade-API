using Microsoft.EntityFrameworkCore.Migrations;

namespace LebaneseHomemade.Migrations
{
    public partial class removephotoextension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Photos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Photos",
                type: "varchar(4)",
                nullable: false,
                defaultValue: "");
        }
    }
}
