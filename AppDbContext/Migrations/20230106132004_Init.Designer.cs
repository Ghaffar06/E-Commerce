﻿// <auto-generated />
using System;
using AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppDbContext.Migrations
{
    [DbContext(typeof(EcommerceDbContext))]
    [Migration("20230106132004_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppDbContext.Models.Attribute", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<long>("ValueTypeId")
                        .HasColumnName("value_type_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ValueTypeId");

                    b.ToTable("attribute");
                });

            modelBuilder.Entity("AppDbContext.Models.AttributeProductValue", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("AttributeId")
                        .HasColumnName("attribute_id")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ProductId");

                    b.ToTable("attribute_product_value");
                });

            modelBuilder.Entity("AppDbContext.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<string>("ImageUrl")
                        .HasColumnName("image_url")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("AppDbContext.Models.CategoryAttribute", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("AttributeId")
                        .HasColumnName("attribute_id")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Required")
                        .IsRequired()
                        .HasColumnName("required")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("category_attribute");
                });

            modelBuilder.Entity("AppDbContext.Models.CategoryProduct", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("category_product");
                });

            modelBuilder.Entity("AppDbContext.Models.Delivery", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("DeliveryPrice")
                        .IsRequired()
                        .HasColumnName("delivery_price")
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10);

                    b.Property<TimeSpan>("ExpectedTime")
                        .HasColumnName("expected_time")
                        .HasColumnType("time");

                    b.Property<long>("SellerAssistantId")
                        .HasColumnName("seller_assistant_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Vehicle")
                        .IsRequired()
                        .HasColumnName("vehicle")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("delivery");
                });

            modelBuilder.Entity("AppDbContext.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("AddressId")
                        .HasColumnName("address_id")
                        .HasColumnType("bigint");

                    b.Property<long>("DeliveryId")
                        .HasColumnName("delivery_id")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Rate")
                        .HasColumnName("rate")
                        .HasColumnType("numeric(8, 2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnName("total_price")
                        .HasColumnType("numeric(8, 2)");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("AppDbContext.Models.OrderProduct", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasColumnType("nchar(200)")
                        .IsFixedLength(true)
                        .HasMaxLength(200);

                    b.Property<long>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("numeric(8, 2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_product");
                });

            modelBuilder.Entity("AppDbContext.Models.OrderState", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Note")
                        .HasColumnName("note")
                        .HasColumnType("nchar(300)")
                        .IsFixedLength(true)
                        .HasMaxLength(300);

                    b.Property<long>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("bigint");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("state")
                        .HasColumnType("nchar(100)")
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("order_state");
                });

            modelBuilder.Entity("AppDbContext.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ImageUrl")
                        .HasColumnName("image_url")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("float");

                    b.Property<string>("PriceIsInteger")
                        .IsRequired()
                        .HasColumnName("price_is_integer")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<decimal>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("numeric(8, 2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnName("unit")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("AppDbContext.Models.Rate", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("bigint");

                    b.Property<int?>("Rate1")
                        .HasColumnName("rate")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("rate");
                });

            modelBuilder.Entity("AppDbContext.Models.ValueType", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("value_type");
                });

            modelBuilder.Entity("AppDbContext.Models.Attribute", b =>
                {
                    b.HasOne("AppDbContext.Models.ValueType", "ValueType")
                        .WithMany("Attribute")
                        .HasForeignKey("ValueTypeId")
                        .HasConstraintName("FK_attribute_value_type")
                        .IsRequired();
                });

            modelBuilder.Entity("AppDbContext.Models.AttributeProductValue", b =>
                {
                    b.HasOne("AppDbContext.Models.Attribute", "Attribute")
                        .WithMany("AttributeProductValue")
                        .HasForeignKey("AttributeId")
                        .HasConstraintName("FK_attribute_product_value_attribute")
                        .IsRequired();

                    b.HasOne("AppDbContext.Models.Product", "Product")
                        .WithMany("AttributeProductValue")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_attribute_product_value_product")
                        .IsRequired();
                });

            modelBuilder.Entity("AppDbContext.Models.CategoryAttribute", b =>
                {
                    b.HasOne("AppDbContext.Models.Attribute", "Attribute")
                        .WithMany("CategoryAttribute")
                        .HasForeignKey("AttributeId")
                        .HasConstraintName("FK_category_attribute_attribute")
                        .IsRequired();

                    b.HasOne("AppDbContext.Models.Category", "Category")
                        .WithMany("CategoryAttribute")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_category_attribute_category")
                        .IsRequired();
                });

            modelBuilder.Entity("AppDbContext.Models.CategoryProduct", b =>
                {
                    b.HasOne("AppDbContext.Models.Category", "Category")
                        .WithMany("CategoryProduct")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_category_product_category")
                        .IsRequired();

                    b.HasOne("AppDbContext.Models.Product", "Product")
                        .WithMany("CategoryProduct")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_category_product_product")
                        .IsRequired();
                });

            modelBuilder.Entity("AppDbContext.Models.Order", b =>
                {
                    b.HasOne("AppDbContext.Models.Delivery", "Delivery")
                        .WithMany("Order")
                        .HasForeignKey("DeliveryId")
                        .HasConstraintName("FK_order_delivery")
                        .IsRequired();
                });

            modelBuilder.Entity("AppDbContext.Models.OrderProduct", b =>
                {
                    b.HasOne("AppDbContext.Models.Order", "Order")
                        .WithMany("OrderProduct")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_order_product_order")
                        .IsRequired();

                    b.HasOne("AppDbContext.Models.Product", "Product")
                        .WithMany("OrderProduct")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_order_product_product")
                        .IsRequired();
                });

            modelBuilder.Entity("AppDbContext.Models.OrderState", b =>
                {
                    b.HasOne("AppDbContext.Models.Order", "Order")
                        .WithMany("OrderState")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_order_state_order")
                        .IsRequired();
                });

            modelBuilder.Entity("AppDbContext.Models.Rate", b =>
                {
                    b.HasOne("AppDbContext.Models.Product", "Product")
                        .WithMany("Rate")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_rate_product")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
