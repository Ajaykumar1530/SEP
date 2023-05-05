using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterView.Migrations
{
    public partial class AddImageColumnToCandidatesList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "CandidatesList",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "CandidatesList");
        }
    }
}
