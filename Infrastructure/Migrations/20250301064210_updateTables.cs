using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "TbProviderProfile");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TbServices",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TbServices",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TbProviderProfile",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
