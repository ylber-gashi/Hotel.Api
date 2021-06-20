using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Api.Infrastructure.Persistence.Migrations
{
    public partial class Gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPayed",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsPayed",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
