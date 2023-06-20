﻿// <auto-generated />
using System;
using FarmFood.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmFood.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230620101410_Update-15")]
    partial class Update15
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarmFood.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("FarmFood.Data.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cityOfOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dateOfRegistration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("sellerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sellerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FarmFood.Data.Models.ShopCart", b =>
                {
                    b.Property<string>("ShopCartId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ShopCartId");

                    b.ToTable("ShopCart");
                });

            modelBuilder.Entity("FarmFood.Data.Models.ShopCartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("productid")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("shopCartID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("productid");

                    b.HasIndex("shopCartID");

                    b.ToTable("ShopCartItem");
                });

            modelBuilder.Entity("FarmFood.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityOfResidence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telegram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VKontakte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatsApp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FarmFood.Data.Models.Product", b =>
                {
                    b.HasOne("FarmFood.Data.Models.Category", "Category")
                        .WithMany("products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FarmFood.Data.Models.ShopCartItem", b =>
                {
                    b.HasOne("FarmFood.Data.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productid");

                    b.HasOne("FarmFood.Data.Models.ShopCart", null)
                        .WithMany("listShopCartItems")
                        .HasForeignKey("shopCartID");

                    b.Navigation("product");
                });

            modelBuilder.Entity("FarmFood.Data.Models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("FarmFood.Data.Models.ShopCart", b =>
                {
                    b.Navigation("listShopCartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
