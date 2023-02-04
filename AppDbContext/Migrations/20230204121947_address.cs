using Microsoft.EntityFrameworkCore.Migrations;

namespace AppDbContext.Migrations
{
    public partial class address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address_id",
                table: "order");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "order");

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
