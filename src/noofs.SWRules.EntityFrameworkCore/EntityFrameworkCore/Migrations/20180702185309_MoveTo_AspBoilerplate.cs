using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace noofs.SWRules.EntityFrameworkCore.Migrations
{
    public partial class MoveTo_AspBoilerplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Powers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Powers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Powers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Powers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Powers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Powers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Powers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Powers");
        }
    }
}
