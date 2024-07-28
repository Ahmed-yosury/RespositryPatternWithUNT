using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RespositryPatternWithUNT.ef.Migrations
{
    /// <inheritdoc />
    public partial class updatebookAndAutherTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutherId",
                table: "books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutherId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
