using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolunTEENProject.Migrations
{
    public partial class AddedPartnerMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_AspNetUsers_HeadRepresentativeId",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Partners_HeadRepresentativeId",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "HeadRepresentativeId",
                table: "Partners");

            migrationBuilder.AddColumn<string>(
                name: "PartnerLogo",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressSecondLine",
                table: "Opportunities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressSecondLine",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PartnerMembers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerMembers", x => new { x.UserId, x.PartnerId });
                    table.ForeignKey(
                        name: "FK_PartnerMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartnerMembers_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerMembers_PartnerId",
                table: "PartnerMembers",
                column: "PartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerMembers");

            migrationBuilder.DropColumn(
                name: "PartnerLogo",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "AddressSecondLine",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "AddressSecondLine",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "HeadRepresentativeId",
                table: "Partners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_HeadRepresentativeId",
                table: "Partners",
                column: "HeadRepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_AspNetUsers_HeadRepresentativeId",
                table: "Partners",
                column: "HeadRepresentativeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
