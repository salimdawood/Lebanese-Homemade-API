using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LebaneseHomemade.Migrations
{
    public partial class NamingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemModel_Menus_MenuId",
                table: "ItemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoModel_Cards_CardId",
                table: "PhotoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotoModel",
                table: "PhotoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemModel",
                table: "ItemModel");

            migrationBuilder.RenameTable(
                name: "PhotoModel",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "ItemModel",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoModel_CardId",
                table: "Photos",
                newName: "IX_Photos_CardId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemModel_MenuId",
                table: "Items",
                newName: "IX_Items_MenuId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Menus_MenuId",
                table: "Items",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Cards_CardId",
                table: "Photos",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Menus_MenuId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Cards_CardId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "PhotoModel");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "ItemModel");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_CardId",
                table: "PhotoModel",
                newName: "IX_PhotoModel_CardId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_MenuId",
                table: "ItemModel",
                newName: "IX_ItemModel_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotoModel",
                table: "PhotoModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemModel",
                table: "ItemModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemModel_Menus_MenuId",
                table: "ItemModel",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoModel_Cards_CardId",
                table: "PhotoModel",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
