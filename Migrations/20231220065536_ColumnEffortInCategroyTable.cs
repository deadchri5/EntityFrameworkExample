using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efejemplo.Migrations
{
    /// <inheritdoc />
    public partial class ColumnEffortInCategroyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Effort",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Effort",
                table: "Category");
        }
    }
}
