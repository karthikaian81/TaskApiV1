using Microsoft.EntityFrameworkCore.Migrations;
using TaskApiV1.Models.Properties;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class AddLastCreatedDateWithDefaultgetdatevalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TestTodoAppFormat>("CreatedDate", "TestTodoAppFormat", defaultValueSql: "Getdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
