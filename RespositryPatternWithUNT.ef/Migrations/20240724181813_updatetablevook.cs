using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RespositryPatternWithUNT.ef.Migrations
{
    /// <inheritdoc />
    public partial class updatetablevook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photopath",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photopath",
                table: "books");
        }
    }
}
