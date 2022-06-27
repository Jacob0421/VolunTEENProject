using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunTEENProject.Migrations
{
    public partial class AddedPartnerSecondLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressSecondLine",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressSecondLine",
                table: "Partners");
        }
    }
}
