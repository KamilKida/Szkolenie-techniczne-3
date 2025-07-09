using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebAPI.Reservations.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserReservations_RoomId",
                schema: "Geo",
                table: "UserReservations",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReservations_Rooms_RoomId",
                schema: "Geo",
                table: "UserReservations",
                column: "RoomId",
                principalSchema: "Geo",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReservations_Rooms_RoomId",
                schema: "Geo",
                table: "UserReservations");

            migrationBuilder.DropIndex(
                name: "IX_UserReservations_RoomId",
                schema: "Geo",
                table: "UserReservations");
        }
    }
}
