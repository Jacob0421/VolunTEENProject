using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunTEENProject.Migrations
{
    public partial class ModifiedEndUserPostal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "AspNetUsers",
                newName: "ZipCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "AspNetUsers",
                newName: "PostalCode");
        }
    }
}
