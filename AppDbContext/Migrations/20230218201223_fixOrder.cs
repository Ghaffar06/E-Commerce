using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppDbContext.Migrations
{
    public partial class fixOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_delivery",
                table: "order");

            migrationBuilder.DropTable(
                name: "delivery");

            migrationBuilder.DropIndex(
                name: "IX_order_delivery_id",
                table: "order");

            migrationBuilder.DropColumn(
                name: "delivery_id",
                table: "order");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "order");

            migrationBuilder.AddColumn<string>(
                name: "customer_id",
                table: "order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deliverer_id",
                table: "order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DelivererId1",
                table: "order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_deliverer_id",
                table: "order",
                column: "deliverer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_DelivererId1",
                table: "order",
                column: "DelivererId1");

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer",
                table: "order",
                column: "deliverer_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_AspNetUsers_DelivererId1",
                table: "order",
                column: "DelivererId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_customer",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_AspNetUsers_DelivererId1",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_deliverer_id",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_DelivererId1",
                table: "order");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "order");

            migrationBuilder.DropColumn(
                name: "deliverer_id",
                table: "order");

            migrationBuilder.DropColumn(
                name: "DelivererId1",
                table: "order");

            migrationBuilder.AddColumn<int>(
                name: "delivery_id",
                table: "order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    delivery_price = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    expected_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    seller_assistant_id = table.Column<int>(type: "int", nullable: false),
                    vehicle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_delivery_id",
                table: "order",
                column: "delivery_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_delivery",
                table: "order",
                column: "delivery_id",
                principalTable: "delivery",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
