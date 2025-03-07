using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbServices",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbReview",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbReview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbReview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbReview",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbProviderProfile",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbProviderProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbProviderProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbProviderProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbProviderAvailability",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbProviderAvailability",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbProviderAvailability",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbProviderAvailability",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbPayment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbPayment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbPayment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbPayment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCustomerProfile",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbCustomerProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbCustomerProfile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbCustomerProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbBooking",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbBooking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TbBooking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbBooking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TbNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbNotifications_TbCustomerProfile_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "TbCustomerProfile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbNotifications_CustomerId",
                table: "TbNotifications",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbNotifications");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbServices");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbServices");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbServices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbReview");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbReview");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbReview");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbProviderProfile");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbProviderProfile");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbProviderProfile");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbProviderAvailability");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbProviderAvailability");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbProviderAvailability");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbProviderAvailability");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbPayment");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbPayment");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbPayment");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbPayment");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbCustomerProfile");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbCustomerProfile");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbCustomerProfile");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbCategory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbCategory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbBooking");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TbBooking");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbBooking");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbServices",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbReview",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbProviderProfile",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCustomerProfile",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TbBooking",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");
        }
    }
}
