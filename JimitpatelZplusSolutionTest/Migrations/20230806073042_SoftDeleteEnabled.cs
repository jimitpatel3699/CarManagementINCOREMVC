using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JimitpatelZplusSolutionTest.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteEnabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "cars");
        }
    }
}
