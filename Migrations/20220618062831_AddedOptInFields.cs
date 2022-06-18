using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunTEENProject.Migrations
{
    public partial class AddedOptInFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EMailOptIn",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TextOptIn",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMailOptIn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TextOptIn",
                table: "AspNetUsers");
        }
    }
}
