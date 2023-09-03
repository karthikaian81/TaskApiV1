using Microsoft.EntityFrameworkCore.Migrations;
using TaskApiV1.Controllers;
using TaskApiV1.Models.Properties;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class AddLastCreatedDateWithDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TestTodoAppFormat>("EstimatedCompletedOn", "TestTodoAppFormat", nullable:false,type:"Date",defaultValueSql: "Getdate()+5");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
