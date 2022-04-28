using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBookingApp.API.Migrations
{
    public partial class changefeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedbackType",
                table: "FeedBacks");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "FeedBacks");

            migrationBuilder.AddColumn<string>(
                name: "FeedbackType",
                table: "FeedBacks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
