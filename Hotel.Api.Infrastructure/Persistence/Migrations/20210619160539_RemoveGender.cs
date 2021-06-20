using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Api.Infrastructure.Persistence.Migrations
{
    public partial class RemoveGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserId1",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId1",
                table: "Payments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserId1",
                table: "Payments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
