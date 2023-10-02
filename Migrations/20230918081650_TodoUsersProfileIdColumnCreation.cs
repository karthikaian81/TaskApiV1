using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class TodoUsersProfileIdColumnCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "TestTodoAppFormats",
                type: "int",
                nullable: false,
                defaultValueSql:"0"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "TestTodoAppFormats");
        }
    }
}
