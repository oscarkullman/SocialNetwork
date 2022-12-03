using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateFollowings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Users_FollowId",
                table: "Followings");

            migrationBuilder.RenameColumn(
                name: "FollowId",
                table: "Followings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_FollowId",
                table: "Followings",
                newName: "IX_Followings_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Users_UserId",
                table: "Followings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Users_UserId",
                table: "Followings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Followings",
                newName: "FollowId");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_UserId",
                table: "Followings",
                newName: "IX_Followings_FollowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Users_FollowId",
                table: "Followings",
                column: "FollowId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
