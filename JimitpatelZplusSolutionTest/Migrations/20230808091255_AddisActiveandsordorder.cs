using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JimitpatelZplusSolutionTest.Migrations
{
    /// <inheritdoc />
    public partial class AddisActiveandsordorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CarCreateVM",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "CarCreateVM",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "CarCreateVM");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "CarCreateVM");
        }
    }
}
