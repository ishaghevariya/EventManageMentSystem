using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBookingApp.API.Migrations
{
    public partial class renamecolname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VenuType",
                table: "Bookings",
                newName: "VenueType");

            migrationBuilder.RenameColumn(
                name: "IsCancle",
                table: "Bookings",
                newName: "IsCancel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VenueType",
                table: "Bookings",
                newName: "VenuType");

            migrationBuilder.RenameColumn(
                name: "IsCancel",
                table: "Bookings",
                newName: "IsCancle");
        }
    }
}
