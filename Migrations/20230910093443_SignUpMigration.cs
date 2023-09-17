using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class SignUpMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoUsersAppFormats",
                table: "TodoUsersAppFormats");

            migrationBuilder.RenameTable(
                name: "TodoUsersAppFormats",
                newName: "TodoUsersProfileAppFormats");

            migrationBuilder.DropColumn(name: "UserId", table: "TodoUsersProfileAppFormats");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TodoUsersProfileAppFormats",
                type: "int",
                nullable: false
               );              

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "TodoUsersProfileAppFormats",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoUsersProfileAppFormats",
                table: "TodoUsersProfileAppFormats",
                column: "ProfileId");

            migrationBuilder.CreateTable(
                name: "TodoUserSignupsFormat",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoUserSignupsFormat", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoUsersProfileAppFormats_UserId",
                table: "TodoUsersProfileAppFormats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoUsersProfileAppFormats_TodoUserSignupsFormat_UserId",
                table: "TodoUsersProfileAppFormats",
                column: "UserId",
                principalTable: "TodoUserSignupsFormat",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoUsersProfileAppFormats_TodoUserSignupsFormat_UserId",
                table: "TodoUsersProfileAppFormats");

            migrationBuilder.DropTable(
                name: "TodoUserSignupsFormat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoUsersProfileAppFormats",
                table: "TodoUsersProfileAppFormats");

            migrationBuilder.DropIndex(
                name: "IX_TodoUsersProfileAppFormats_UserId",
                table: "TodoUsersProfileAppFormats");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "TodoUsersProfileAppFormats");

            migrationBuilder.RenameTable(
                name: "TodoUsersProfileAppFormats",
                newName: "TodoUsersAppFormats");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TodoUsersAppFormats",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "TodoUsersAppFormats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoUsersAppFormats",
                table: "TodoUsersAppFormats",
                column: "UserId");
        }
    }
}
