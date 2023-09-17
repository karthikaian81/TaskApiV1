using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApiV1.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeysetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoUsersProfileAppFormats_TodoUserSignupsFormat_UserId",
                table: "TodoUsersProfileAppFormats");

            migrationBuilder.DropIndex(
                name: "IX_TodoUsersProfileAppFormats_UserId",
                table: "TodoUsersProfileAppFormats");

            migrationBuilder.Sql("truncate table TodoUsersProfileAppFormats",true);

            migrationBuilder.AlterColumn<string>(
                name: "ResetToken",
                table: "TodoUserSignupsFormat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoUserSignupsFormat_UserId",
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
                name: "FK_TodoUserSignupsFormat_UserId",
                table: "TodoUsersProfileAppFormats");

            migrationBuilder.AlterColumn<string>(
                name: "ResetToken",
                table: "TodoUserSignupsFormat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
