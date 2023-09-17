using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class Usersignupcolumnsdefaultchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ResetTokenExpireson",
                table: "TodoUserSignupsFormat",
                nullable: true,
                defaultValue:null
                );

            migrationBuilder.AlterColumn<DateTime>(
               name: "Updatedon",
               table: "TodoUserSignupsFormat",
               nullable: true,
               defaultValue: null
               );

            migrationBuilder.AlterColumn<DateTime>(
              name: "Verifiedon",
              table: "TodoUserSignupsFormat",
              nullable: true,
              defaultValue: null
              );

            migrationBuilder.AlterColumn<DateTime>(
             name: "Createdon",
             table: "TodoUserSignupsFormat",
             nullable: false,
             defaultValueSql:"getdate()"
             );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ResetTokenExpireson",
                table: "TodoUserSignupsFormat",
                type: "datetime2",
                nullable: true
                );
        }
    }
}
