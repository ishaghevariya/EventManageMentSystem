using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBookingApp.API.Migrations
{
    public partial class removerow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
