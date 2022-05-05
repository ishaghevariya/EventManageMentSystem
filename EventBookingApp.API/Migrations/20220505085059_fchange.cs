using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBookingApp.API.Migrations
{
    public partial class fchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Bookings_bookingId",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_bookingId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "bookingId",
                table: "FeedBacks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bookingId",
                table: "FeedBacks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_bookingId",
                table: "FeedBacks",
                column: "bookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Bookings_bookingId",
                table: "FeedBacks",
                column: "bookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
