using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeyToFollows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Users_UserId",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_UserId",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Followings");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowId",
                table: "Followings",
                column: "FollowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Users_FollowId",
                table: "Followings",
                column: "FollowId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Users_FollowId",
                table: "Followings");

            migrationBuilder.DropIndex(
                name: "IX_Followings_FollowId",
                table: "Followings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Followings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Followings_UserId",
                table: "Followings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Users_UserId",
                table: "Followings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
