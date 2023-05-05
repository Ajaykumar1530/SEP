using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterView.Migrations
{
    public partial class AddNewAdminModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Admin",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   MobileNo = table.Column<long>(type: "bigint", nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Admin", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Admin");
        }
    }
}
