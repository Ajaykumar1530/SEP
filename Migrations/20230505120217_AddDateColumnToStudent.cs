using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterView.Migrations
{
    public partial class AddDateColumnToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfTest",
                table: "Students",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YOP",
                table: "Students",
                type: "int",
                nullable: true,
                defaultValue: 0);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "DateOfTest",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "YOP",
                table: "Students");
        }
    }
}
