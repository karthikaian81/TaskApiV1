using Microsoft.EntityFrameworkCore.Migrations;
using TaskApiV1.Models.Properties;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class AlterEstimatedColumnCreation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TestTodoAppFormat>(
               name: "EstimatedCompletedOn",
               table: "TestTodoAppFormat",
                defaultValueSql: "cast(Getdate()+5 as date)",
                nullable: false
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
