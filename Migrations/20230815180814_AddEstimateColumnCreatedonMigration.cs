using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class AddEstimateColumnCreatedonMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedCompletedOn",
                table: "TestTodoAppFormat",
                nullable: false, 
                type: "Date", 
                defaultValueSql: "cast(Getdate()+5 as date)"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedCompletedOn",
                table: "TestTodoAppFormat");
        }
    }
}
