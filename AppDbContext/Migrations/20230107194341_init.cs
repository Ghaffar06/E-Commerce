using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AppDbContext.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(unicode: false, maxLength: 300, nullable: true),
                    image_url = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seller_assistant_id = table.Column<int>(nullable: false),
                    expected_time = table.Column<TimeSpan>(nullable: false),
                    vehicle = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    delivery_price = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    price = table.Column<double>(nullable: false),
                    price_is_integer = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(8, 2)", nullable: false),
                    image_url = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    unit = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "value_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_value_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    delivery_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    total_price = table.Column<decimal>(type: "numeric(8, 2)", nullable: false),
                    address_id = table.Column<int>(nullable: false),
                    rate = table.Column<decimal>(type: "numeric(8, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_delivery",
                        column: x => x.delivery_id,
                        principalTable: "delivery",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "category_product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: false),
                    category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_product_category",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_category_product_product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rate",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    rate = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rate", x => x.id);
                    table.ForeignKey(
                        name: "FK_rate_product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attribute",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    value_type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attribute", x => x.id);
                    table.ForeignKey(
                        name: "FK_attribute_value_type",
                        column: x => x.value_type_id,
                        principalTable: "value_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: false),
                    order_id = table.Column<int>(nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(8, 2)", nullable: false),
                    notes = table.Column<string>(fixedLength: true, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_product_order",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_product_product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_state",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(nullable: false),
                    state = table.Column<string>(fixedLength: true, maxLength: 100, nullable: false),
                    note = table.Column<string>(fixedLength: true, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_state", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_state_order",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "attribute_product_value",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attribute_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    value = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attribute_product_value", x => x.id);
                    table.ForeignKey(
                        name: "FK_attribute_product_value_attribute",
                        column: x => x.attribute_id,
                        principalTable: "attribute",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_attribute_product_value_product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "category_attribute",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(nullable: false),
                    attribute_id = table.Column<int>(nullable: false),
                    required = table.Column<string>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_attribute", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_attribute_attribute",
                        column: x => x.attribute_id,
                        principalTable: "attribute",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_category_attribute_category",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attribute_value_type_id",
                table: "attribute",
                column: "value_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_attribute_product_value_attribute_id",
                table: "attribute_product_value",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_attribute_product_value_product_id",
                table: "attribute_product_value",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_attribute_attribute_id",
                table: "category_attribute",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_attribute_category_id",
                table: "category_attribute",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_product_category_id",
                table: "category_product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_product_product_id",
                table: "category_product",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_delivery_id",
                table: "order",
                column: "delivery_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_product_order_id",
                table: "order_product",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_product_product_id",
                table: "order_product",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_state_order_id",
                table: "order_state",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_rate_product_id",
                table: "rate",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attribute_product_value");

            migrationBuilder.DropTable(
                name: "category_attribute");

            migrationBuilder.DropTable(
                name: "category_product");

            migrationBuilder.DropTable(
                name: "order_product");

            migrationBuilder.DropTable(
                name: "order_state");

            migrationBuilder.DropTable(
                name: "rate");

            migrationBuilder.DropTable(
                name: "attribute");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "value_type");

            migrationBuilder.DropTable(
                name: "delivery");
        }
    }
}
