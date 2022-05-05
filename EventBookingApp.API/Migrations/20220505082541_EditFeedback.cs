using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBookingApp.API.Migrations
{
    public partial class EditFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_ApplicationUsers_UserId",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_UserId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "FeedBacks");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Bookings_bookingId",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_bookingId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "bookingId",
                table: "FeedBacks");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "FeedBacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_UserId",
                table: "FeedBacks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_ApplicationUsers_UserId",
                table: "FeedBacks",
                column: "UserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
