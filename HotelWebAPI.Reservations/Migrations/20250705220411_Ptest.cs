using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebAPI.Main.Migrations
{
    /// <inheritdoc />
    public partial class Ptest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserReservations_RoomId",
                schema: "Geo",
                table: "UserReservations",
                column: "RoomId",
                unique: true);

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
    }
}
