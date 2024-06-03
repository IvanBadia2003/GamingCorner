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
    [Migration("20240603180232_InitialCreate8")]
    partial class InitialCreate8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GamingCorner.Models.Console_", b =>
                {
                    b.Property<int>("ConsoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsoleId"), 1L, 1);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Specifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ConsoleId");

                    b.HasIndex("PlatformId");

                    b.ToTable("Consoles");

                    b.HasData(
                        new
                        {
                            ConsoleId = 1,
                            Available = true,
                            ImageURL = "",
                            Name = "Play Station 4",
                            PlatformId = 2,
                            Price = 300m,
                            Specifications = "Ta bien",
                            Stock = 16
                        },
                        new
                        {
                            ConsoleId = 2,
                            Available = true,
                            ImageURL = "",
                            Name = "Xbox 360",
                            PlatformId = 3,
                            Price = 265m,
                            Specifications = "Ta bien pero no tanto",
                            Stock = 5
                        });
                });

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

            modelBuilder.Entity("GamingCorner.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderId"), 1L, 1);

                    b.Property<string>("BackgroundImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            GenderId = 1,
                            BackgroundImg = "",
                            CharacterImg = "",
                            Name = "RPG"
                        },
                        new
                        {
                            GenderId = 2,
                            BackgroundImg = "",
                            CharacterImg = "",
                            Name = "Shooter"
                        },
                        new
                        {
                            GenderId = 3,
                            BackgroundImg = "",
                            CharacterImg = "",
                            Name = "Estrategia"
                        },
                        new
                        {
                            GenderId = 4,
                            BackgroundImg = "",
                            CharacterImg = "",
                            Name = "Accion"
                        },
                        new
                        {
                            GenderId = 5,
                            BackgroundImg = "",
                            CharacterImg = "",
                            Name = "Deportes"
                        });
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

                    b.Property<int?>("Console_ConsoleId")
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

                    b.HasIndex("Console_ConsoleId");

                    b.HasIndex("OrderId");

                    b.HasIndex("VideogameId");

                    b.ToTable("OrderLines");
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

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            PlatformId = 1,
                            Name = "Steam"
                        },
                        new
                        {
                            PlatformId = 2,
                            Name = "Play Station"
                        },
                        new
                        {
                            PlatformId = 3,
                            Name = "Xbox"
                        },
                        new
                        {
                            PlatformId = 4,
                            Name = "Switch"
                        });
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

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            PhoneNumber = "601112734"
                        },
                        new
                        {
                            UserId = 2,
                            Admin = true,
                            Email = "ivan@gmail.com",
                            ImageURL = "",
                            Name = "Ivan",
                            Password = "12345",
                            PhoneNumber = "123456789"
                        },
                        new
                        {
                            UserId = 3,
                            Admin = false,
                            Email = "adrian@gmail.com",
                            ImageURL = "",
                            Name = "Adrian",
                            Password = "00000",
                            PhoneNumber = "987654321"
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

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("VideogameId");

                    b.HasIndex("PlatformId");

                    b.ToTable("Videogames");

                    b.HasData(
                        new
                        {
                            VideogameId = 1,
                            Available = true,
                            Description = "Altos carros voladores",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp",
                            Name = "Rocket League",
                            Pegi = 12,
                            PlatformId = 1,
                            Price = 15m,
                            Stock = 3
                        },
                        new
                        {
                            VideogameId = 2,
                            Available = true,
                            Description = "Gran Robo de Autos",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp",
                            Name = "GTA 5",
                            Pegi = 18,
                            PlatformId = 2,
                            Price = 13m,
                            Stock = 7
                        },
                        new
                        {
                            VideogameId = 3,
                            Available = true,
                            Description = "Aventura épica en un mundo de fantasía",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp",
                            Name = "The Witcher 3",
                            Pegi = 18,
                            PlatformId = 1,
                            Price = 20m,
                            Stock = 5
                        },
                        new
                        {
                            VideogameId = 4,
                            Available = true,
                            Description = "Juego de construcción y aventuras",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp",
                            Name = "Minecraft",
                            Pegi = 7,
                            PlatformId = 3,
                            Price = 25m,
                            Stock = 10
                        },
                        new
                        {
                            VideogameId = 5,
                            Available = true,
                            Description = "Juego de supervivencia y construcción",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp",
                            Name = "Fortnite",
                            Pegi = 12,
                            PlatformId = 1,
                            Price = 0m,
                            Stock = 8
                        },
                        new
                        {
                            VideogameId = 6,
                            Available = true,
                            Description = "Juego de disparos en equipo",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp",
                            Name = "Overwatch",
                            Pegi = 12,
                            PlatformId = 2,
                            Price = 30m,
                            Stock = 6
                        },
                        new
                        {
                            VideogameId = 7,
                            Available = true,
                            Description = "Simulación de fútbol",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp",
                            Name = "FIFA 21",
                            Pegi = 3,
                            PlatformId = 3,
                            Price = 50m,
                            Stock = 12
                        },
                        new
                        {
                            VideogameId = 8,
                            Available = true,
                            Description = "Aventura en un mundo futurista",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp",
                            Name = "Cyberpunk 2077",
                            Pegi = 18,
                            PlatformId = 1,
                            Price = 60m,
                            Stock = 4
                        },
                        new
                        {
                            VideogameId = 9,
                            Available = true,
                            Description = "Aventura en el Viejo Oeste",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp",
                            Name = "Red Dead Redemption 2",
                            Pegi = 18,
                            PlatformId = 2,
                            Price = 40m,
                            Stock = 9
                        },
                        new
                        {
                            VideogameId = 10,
                            Available = true,
                            Description = "Aventura de vikingos",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp",
                            Name = "Assassin's Creed Valhalla",
                            Pegi = 18,
                            PlatformId = 3,
                            Price = 55m,
                            Stock = 7
                        },
                        new
                        {
                            VideogameId = 11,
                            Available = true,
                            Description = "Juego de disparos en primera persona",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp",
                            Name = "Call of Duty: Modern Warfare",
                            Pegi = 18,
                            PlatformId = 1,
                            Price = 50m,
                            Stock = 11
                        },
                        new
                        {
                            VideogameId = 12,
                            Available = true,
                            Description = "Aventura en un mundo postapocalíptico",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp",
                            Name = "Horizon Zero Dawn",
                            Pegi = 16,
                            PlatformId = 1,
                            Price = 35m,
                            Stock = 5
                        },
                        new
                        {
                            VideogameId = 13,
                            Available = true,
                            Description = "Simulación de granja",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp",
                            Name = "Stardew Valley",
                            Pegi = 7,
                            PlatformId = 4,
                            Price = 20m,
                            Stock = 8
                        },
                        new
                        {
                            VideogameId = 14,
                            Available = true,
                            Description = "Juego de deducción social",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp",
                            Name = "Among Us",
                            Pegi = 10,
                            PlatformId = 1,
                            Price = 5m,
                            Stock = 15
                        },
                        new
                        {
                            VideogameId = 15,
                            Available = true,
                            Description = "Aventura en el mundo de Hyrule",
                            ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png",
                            Name = "The Legend of Zelda: Breath of the Wild",
                            Pegi = 12,
                            PlatformId = 4,
                            Price = 60m,
                            Stock = 6
                        });
                });

            modelBuilder.Entity("GamingCorner.Models.VideogameGender", b =>
                {
                    b.Property<int>("VideogameId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.HasKey("VideogameId", "GenderId");

                    b.HasIndex("GenderId");

                    b.ToTable("VideogameGenders");

                    b.HasData(
                        new
                        {
                            VideogameId = 1,
                            GenderId = 1
                        },
                        new
                        {
                            VideogameId = 2,
                            GenderId = 2
                        },
                        new
                        {
                            VideogameId = 3,
                            GenderId = 3
                        },
                        new
                        {
                            VideogameId = 4,
                            GenderId = 4
                        },
                        new
                        {
                            VideogameId = 5,
                            GenderId = 5
                        },
                        new
                        {
                            VideogameId = 6,
                            GenderId = 1
                        },
                        new
                        {
                            VideogameId = 7,
                            GenderId = 2
                        },
                        new
                        {
                            VideogameId = 8,
                            GenderId = 3
                        },
                        new
                        {
                            VideogameId = 9,
                            GenderId = 4
                        },
                        new
                        {
                            VideogameId = 10,
                            GenderId = 5
                        },
                        new
                        {
                            VideogameId = 11,
                            GenderId = 1
                        },
                        new
                        {
                            VideogameId = 12,
                            GenderId = 2
                        },
                        new
                        {
                            VideogameId = 13,
                            GenderId = 3
                        },
                        new
                        {
                            VideogameId = 14,
                            GenderId = 4
                        },
                        new
                        {
                            VideogameId = 15,
                            GenderId = 5
                        });
                });

            modelBuilder.Entity("GamingCorner.Models.Console_", b =>
                {
                    b.HasOne("GamingCorner.Models.Platform", "Platform")
                        .WithMany("consoles")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
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
                    b.HasOne("GamingCorner.Models.Console_", null)
                        .WithMany("Order_lines_Console")
                        .HasForeignKey("Console_ConsoleId");

                    b.HasOne("GamingCorner.Models.Order", null)
                        .WithMany("Order_Lines_Order")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCorner.Models.Videogame", null)
                        .WithMany("Order_lines_Videogame")
                        .HasForeignKey("VideogameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCorner.Models.Videogame", b =>
                {
                    b.HasOne("GamingCorner.Models.Platform", "Platform")
                        .WithMany("videogames")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("GamingCorner.Models.VideogameGender", b =>
                {
                    b.HasOne("GamingCorner.Models.Gender", "Gender")
                        .WithMany("ListVideogameGender")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCorner.Models.Videogame", "Videogame")
                        .WithMany("ListVideogameGender")
                        .HasForeignKey("VideogameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Videogame");
                });

            modelBuilder.Entity("GamingCorner.Models.Console_", b =>
                {
                    b.Navigation("Order_lines_Console");
                });

            modelBuilder.Entity("GamingCorner.Models.Gender", b =>
                {
                    b.Navigation("ListVideogameGender");
                });

            modelBuilder.Entity("GamingCorner.Models.Order", b =>
                {
                    b.Navigation("Order_Lines_Order");
                });

            modelBuilder.Entity("GamingCorner.Models.Platform", b =>
                {
                    b.Navigation("consoles");

                    b.Navigation("videogames");
                });

            modelBuilder.Entity("GamingCorner.Models.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GamingCorner.Models.Videogame", b =>
                {
                    b.Navigation("ListVideogameGender");

                    b.Navigation("Order_lines_Videogame");
                });
#pragma warning restore 612, 618
        }
    }
}
