using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCoulms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbReview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbProviderProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbProviderAvailability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbNotifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbCustomerProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbBooking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbServices");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbReview");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbProviderProfile");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbProviderAvailability");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbPayment");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbNotifications");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbCustomerProfile");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbCategory");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbBooking");
        }
    }
}
