using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelWebAPI.Main.Migrations
{
    /// <inheritdoc />
    public partial class AllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avalible",
                schema: "Geo",
                table: "Rooms",
                newName: "Available");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Geo",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Available",
                schema: "Geo",
                table: "Rooms",
                newName: "Avalible");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Geo",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
