﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaWebApp.ProductAPI.Data;

#nullable disable

namespace PizzaWebApp.ProductAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230923135613_FillData")]
    partial class FillData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaWebApp.ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "Salami, ham, bacon, mushroom, green pepper.",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Pepperoni Special"
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Mushroom, onion, green pepper, sweet corn, black olives.",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Vegetarian"
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Slice tomato.",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Margarita"
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Ham, pineapple.",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Hawaiian"
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "Ham, mushroom, prawns, artichoke, black olives",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Quattro Stagioni"
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "Ham, mushroom",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Capricciosa"
                        },
                        new
                        {
                            ProductId = 7,
                            Description = "Prawns, mushroom.",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Riviera"
                        },
                        new
                        {
                            ProductId = 8,
                            Description = "Pesto base sauce, marinated grilled chicken, mozzarella cheese, tomato.",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Chicken Pesto"
                        },
                        new
                        {
                            ProductId = 9,
                            Description = "Tuna, anchovies, black olives.",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Frutti di Mare"
                        },
                        new
                        {
                            ProductId = 10,
                            Description = "Ham, mushroom, pepperoni, haloumi, green pepper, onion, black olives, tomato, oregano.",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Super Crazy"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
