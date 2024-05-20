﻿// <auto-generated />
using System;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    [DbContext(typeof(GamingCornerContext))]
    [Migration("20240515155059_Migration_User_Videogame")]
    partial class Migration_User_Videogame
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GamingCorner.Models.GamingConsole", b =>
                {
                    b.Property<int>("ConsoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsoleId"), 1L, 1);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Characteristics")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ConsoleId");

                    b.ToTable("GamingConsole");
                });

            modelBuilder.Entity("GamingCorner.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("BackgroundImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("GamingCorner.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("GamingCorner.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderLineId"), 1L, 1);

                    b.Property<int>("ConsoleId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SubtotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VideogameId")
                        .HasColumnType("int");

                    b.HasKey("OrderLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("VideogameId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("GamingCorner.Models.Platform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlatformId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlatformId");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("GamingCorner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Admin = true,
                            Email = "diego@gmail.com",
                            ImageURL = "",
                            Name = "Diego",
                            Password = "12345",
                            PhoneNumber = 601112734
                        },
                        new
                        {
                            UserId = 2,
                            Admin = true,
                            Email = "ivan@gmail.com",
                            ImageURL = "",
                            Name = "Ivan",
                            Password = "12345",
                            PhoneNumber = 123456789
                        },
                        new
                        {
                            UserId = 3,
                            Admin = false,
                            Email = "adrian@gmail.com",
                            ImageURL = "",
                            Name = "Adrian",
                            Password = "00000",
                            PhoneNumber = 987654321
                        });
                });

            modelBuilder.Entity("GamingCorner.Models.Videogame", b =>
                {
                    b.Property<int>("VideogameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VideogameId"), 1L, 1);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pegi")
                        .HasColumnType("int");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("VideogameId");

                    b.ToTable("Videogames");

                    b.HasData(
                        new
                        {
                            VideogameId = 1,
                            Available = true,
                            Category = "",
                            Description = "Altos carros voladores",
                            ImageURL = "",
                            Name = "Rocket League",
                            Pegi = 12,
                            Platform = "Steam",
                            Price = 15m,
                            Stock = 3
                        },
                        new
                        {
                            VideogameId = 2,
                            Available = true,
                            Category = "",
                            Description = "Gran Robo de Autos",
                            ImageURL = "",
                            Name = "GTA 5",
                            Pegi = 18,
                            Platform = "Play Station",
                            Price = 13m,
                            Stock = 7
                        });
                });

            modelBuilder.Entity("GamingCorner.Models.VideogameGenre", b =>
                {
                    b.Property<int>("VideogameId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("VideogameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("VideogameGenre");
                });

            modelBuilder.Entity("GamingCorner.Models.Order", b =>
                {
                    b.HasOne("GamingCorner.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GamingCorner.Models.OrderLine", b =>
                {
                    b.HasOne("GamingCorner.Models.Order", null)
                        .WithMany("Order_Lines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCorner.Models.Videogame", null)
                        .WithMany("Order_lines")
                        .HasForeignKey("VideogameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCorner.Models.VideogameGenre", b =>
                {
                    b.HasOne("GamingCorner.Models.Genre", "Genre")
                        .WithMany("ListVideogameGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCorner.Models.Videogame", "Videogame")
                        .WithMany("ListVideogameGenre")
                        .HasForeignKey("VideogameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Videogame");
                });

            modelBuilder.Entity("GamingCorner.Models.Genre", b =>
                {
                    b.Navigation("ListVideogameGenre");
                });

            modelBuilder.Entity("GamingCorner.Models.Order", b =>
                {
                    b.Navigation("Order_Lines");
                });

            modelBuilder.Entity("GamingCorner.Models.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GamingCorner.Models.Videogame", b =>
                {
                    b.Navigation("ListVideogameGenre");

                    b.Navigation("Order_lines");
                });
#pragma warning restore 612, 618
        }
    }
}
