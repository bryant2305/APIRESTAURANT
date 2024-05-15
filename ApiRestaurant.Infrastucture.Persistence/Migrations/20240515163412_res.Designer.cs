﻿// <auto-generated />
using System;
using ApiRestaurant.Infrastucture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiRestaurant.Infrastucture.Persistence.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    [Migration("20240515163412_res")]
    partial class res
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.Dish", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AmountPeople")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Dish", (string)null);
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.DishIngredients", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DishId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredients");
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.Ingredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Ingredient", (string)null);
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.Mesas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Mesas", (string)null);
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DishSelected")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MesasID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtotal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MesasID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.OrderDish", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DishID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifyBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DishID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderDish");
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.DishIngredients", b =>
                {
                    b.HasOne("ApiRestaurant.Core.Domain.Entity.Dish", "Dish")
                        .WithMany("Ingredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRestaurant.Core.Domain.Entity.Ingredient", "Ingredient")
                        .WithMany("Ingredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.Order", b =>
                {
                    b.HasOne("ApiRestaurant.Core.Domain.Entity.Mesas", "Mesas")
                        .WithMany("Orders")
                        .HasForeignKey("MesasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.OrderDish", b =>
                {
                    b.HasOne("ApiRestaurant.Core.Domain.Entity.Dish", "Dish")
                        .WithMany("OrderDishes")
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiRestaurant.Core.Domain.Entity.Order", "Order")
                        .WithMany("OrderDishes")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.Dish", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("OrderDishes");
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.Ingredient", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.Mesas", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ApiRestaurant.Core.Domain.Entity.Order", b =>
                {
                    b.Navigation("OrderDishes");
                });
#pragma warning restore 612, 618
        }
    }
}