using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterView.Migrations
{
    public partial class AddResumeToCandidateList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
    name: "Resume",
    table: "CandidatesList",
    nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
    name: "Resume",
    table: "CandidatesList");

        }
    }
}
