using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class UsersignupRegisterColumnsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "TodoUserSignupsFormat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Createdon",
                table: "TodoUserSignupsFormat",
                type: "datetime2",
                nullable: false,
                defaultValueSql : "Getdate()",
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<int>(
                name: "PasswordResettedCount",
                table: "TodoUserSignupsFormat",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetToken",
                table: "TodoUserSignupsFormat",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue:""
                );

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpireson",
                table: "TodoUserSignupsFormat",
                type: "datetime2",
                nullable: true,
                defaultValue: DateTime.Now.AddMinutes(20));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updatedon",
                table: "TodoUserSignupsFormat",
                type: "datetime2",
                nullable: true,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<string>(
                name: "VeificationToken",
                table: "TodoUserSignupsFormat",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Verifiedon",
                table: "TodoUserSignupsFormat",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TodoUserSignupsFormat");

            migrationBuilder.DropColumn(
                name: "Createdon",
                table: "TodoUserSignupsFormat");

            migrationBuilder.DropColumn(
                name: "PasswordResettedCount",
                table: "TodoUserSignupsFormat");

            migrationBuilder.DropColumn(
                name: "ResetToken",
                table: "TodoUserSignupsFormat");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpireson",
                table: "TodoUserSignupsFormat");

            migrationBuilder.DropColumn(
                name: "Updatedon",
                table: "TodoUserSignupsFormat");

            migrationBuilder.DropColumn(
                name: "VeificationToken",
                table: "TodoUserSignupsFormat");

            migrationBuilder.DropColumn(
                name: "Verifiedon",
                table: "TodoUserSignupsFormat");
        }
    }
}
