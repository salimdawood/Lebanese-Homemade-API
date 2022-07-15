using Microsoft.EntityFrameworkCore.Migrations;

namespace LebaneseHomemade.Migrations
{
    public partial class arabiccolumninput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Photos",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppLink",
                table: "Cards",
                type: "nvarchar(2083)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstagramLink",
                table: "Cards",
                type: "nvarchar(2083)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaceBookLink",
                table: "Cards",
                type: "nvarchar(2083)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Photos",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "WhatsAppLink",
                table: "Cards",
                type: "varchar(2083)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InstagramLink",
                table: "Cards",
                type: "varchar(2083)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaceBookLink",
                table: "Cards",
                type: "varchar(2083)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldNullable: true);
        }
    }
}
