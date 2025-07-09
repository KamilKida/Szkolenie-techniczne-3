using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebAPI.Reservations.Migrations
{
    /// <inheritdoc />
    public partial class ConfirmReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                schema: "Geo",
                table: "UserReservations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                schema: "Geo",
                table: "UserReservations");
        }
    }
}
