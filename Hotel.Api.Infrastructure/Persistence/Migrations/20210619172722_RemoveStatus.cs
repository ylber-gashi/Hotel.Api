using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Api.Infrastructure.Persistence.Migrations
{
    public partial class RemoveStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");
        }
    }
}
