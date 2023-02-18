using Microsoft.EntityFrameworkCore.Migrations;

namespace AppDbContext.Migrations
{
    public partial class fixOrder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_customer",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_AspNetUsers_DelivererId1",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_DelivererId1",
                table: "order");

            migrationBuilder.DropColumn(
                name: "DelivererId1",
                table: "order");

            migrationBuilder.AlterColumn<string>(
                name: "customer_id",
                table: "order",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                table: "order",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_customer",
                table: "order",
                column: "customer_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_order_deliverer",
                table: "order",
                column: "deliverer_id",
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
                name: "FK_order_deliverer",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_customer_id",
                table: "order");

            migrationBuilder.AlterColumn<string>(
                name: "customer_id",
                table: "order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DelivererId1",
                table: "order",
                type: "nvarchar(450)",
                nullable: true);

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
    }
}
