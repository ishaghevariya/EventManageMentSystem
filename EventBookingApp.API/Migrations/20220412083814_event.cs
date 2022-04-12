using Microsoft.EntityFrameworkCore.Migrations;

namespace EventBookingApp.API.Migrations
{
    public partial class @event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventGallery_Events_EventId",
                table: "EventGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventGallery",
                table: "EventGallery");

            migrationBuilder.RenameTable(
                name: "EventGallery",
                newName: "EventGalleries");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EventGalleries",
                newName: "ImageName");

            migrationBuilder.RenameIndex(
                name: "IX_EventGallery_EventId",
                table: "EventGalleries",
                newName: "IX_EventGalleries_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventGalleries",
                table: "EventGalleries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventGalleries_Events_EventId",
                table: "EventGalleries",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventGalleries_Events_EventId",
                table: "EventGalleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventGalleries",
                table: "EventGalleries");

            migrationBuilder.RenameTable(
                name: "EventGalleries",
                newName: "EventGallery");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "EventGallery",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_EventGalleries_EventId",
                table: "EventGallery",
                newName: "IX_EventGallery_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventGallery",
                table: "EventGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventGallery_Events_EventId",
                table: "EventGallery",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
