using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class userlastmofifiedtablecolumnalters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "TodoUsersAppFormats",
                nullable: true,
                type: "datetime"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                 name: "LastModifiedDate",
                 table: "TodoUsersAppFormats",
                 nullable: false,
                 type: "datetime"
                 );
        }
    }
}
