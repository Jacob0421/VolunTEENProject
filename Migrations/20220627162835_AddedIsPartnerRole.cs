using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunTEENProject.Migrations
{
    public partial class AddedIsPartnerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPartnerRole",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPartnerRole",
                table: "AspNetRoles");
        }
    }
}
