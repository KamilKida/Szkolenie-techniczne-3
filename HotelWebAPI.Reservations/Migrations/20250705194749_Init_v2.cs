using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebAPI.Reservations.Migrations
{
    /// <inheritdoc />
    public partial class Init_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserReservations_DiscountId",
                schema: "Geo",
                table: "UserReservations",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReservations_RoomId",
                schema: "Geo",
                table: "UserReservations",
                column: "RoomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReservations_Discounts_DiscountId",
                schema: "Geo",
                table: "UserReservations",
                column: "DiscountId",
                principalSchema: "Geo",
                principalTable: "Discounts",
                principalColumn: "Id");

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
                name: "FK_UserReservations_Discounts_DiscountId",
                schema: "Geo",
                table: "UserReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReservations_Rooms_RoomId",
                schema: "Geo",
                table: "UserReservations");

            migrationBuilder.DropIndex(
                name: "IX_UserReservations_DiscountId",
                schema: "Geo",
                table: "UserReservations");

            migrationBuilder.DropIndex(
                name: "IX_UserReservations_RoomId",
                schema: "Geo",
                table: "UserReservations");
        }
    }
}
