using Microsoft.EntityFrameworkCore.Migrations;

namespace Friendship.Migrations
{
    public partial class InitialD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserId1",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_UserId1",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Photos");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_UserId",
                table: "Photos");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Photos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId1",
                table: "Photos",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UserId1",
                table: "Photos",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
