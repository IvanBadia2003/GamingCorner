using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GamingCorner.Models;
using System.Security.Cryptography.X509Certificates;
using System.IO.Compression;

namespace GamingCorner.Data
{
    public class GamingCornerContext : DbContext
    {

        public GamingCornerContext(DbContextOptions<GamingCornerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Product)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.ProductId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Videogame)
                .WithMany(v => v.Transactions)
                .HasForeignKey(t => t.VideogameId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Console)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.ConsoleId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<User>()
                .HasMany(v => v.Videogames)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Videogame>()
                .HasOne(v => v.User)
                .WithMany(u => u.Videogames)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<User>()
                .HasKey(u => new { u.UserId });

            modelBuilder.Entity<Videogame>()
                .HasKey(v => new { v.VideogameId });

            modelBuilder.Entity<Console_>()
                .HasKey(c => new { c.ConsoleId });

            modelBuilder.Entity<Platform>()
                .HasKey(p => new { p.PlatformId });

            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Consoles)
                .WithOne(c => c.Platform)
                .HasForeignKey(c => c.PlatformId)
                .OnDelete(DeleteBehavior.Restrict); // Mantén o usa Restrict

            modelBuilder.Entity<Platform>()
                .HasMany(p => p.videogames)
                .WithOne(v => v.Platform)
                .HasForeignKey(v => v.PlatformId)
                .OnDelete(DeleteBehavior.Restrict); // Mantén o usa Restrict
            
            modelBuilder.Entity<Console_>()
                .HasOne(c => c.Platform)
                .WithMany(p => p.Consoles)
                .HasForeignKey(c => c.PlatformId)
                .OnDelete(DeleteBehavior.NoAction); // Evitar ON DELETE CASCADE

            modelBuilder.Entity<Videogame>()
                .HasOne(v => v.Platform)
                .WithMany(p => p.videogames)
                .HasForeignKey(v => v.PlatformId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Gender>()
                .HasKey(ge => new { ge.GenderId });

            modelBuilder.Entity<Product>()
                .HasKey(p => new { p.ProductId });





            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Diego", Address = "C/ La Lectura", Email = "diego@gmail.com", Password = "12345", PhoneNumber = "601112734", Admin = true, ImageURL = "" },
                new User { UserId = 2, Name = "Ivan", Address = "Avda. San Juan de la Peña", Email = "ivan@gmail.com", Password = "12345", PhoneNumber = "123456789", Admin = true, ImageURL = "" },
                new User { UserId = 3, Name = "Adrian", Address = "El Actur", Email = "adrian@gmail.com", Password = "00000", PhoneNumber = "987654321", Admin = false, ImageURL = "" }
            );

            modelBuilder.Entity<Platform>().HasData(
                new Platform { PlatformId = 1, Name = "Steam" },
                new Platform { PlatformId = 2, Name = "Play Station" },
                new Platform { PlatformId = 3, Name = "Xbox" },
                new Platform { PlatformId = 4, Name = "Switch" },
                new Platform { PlatformId = 5, Name = "Ubisoft" },
                new Platform { PlatformId = 6, Name = "Epic Games" }
            );

            modelBuilder.Entity<Console_>().HasData(
                new Console_ { ConsoleId = 1, Name = "Play Station 4", Specifications = "Ta bien", Price = 300, Stock = 16, Available = true, ImageURL = "", PlatformId = 1 },
                new Console_ { ConsoleId = 2, Name = "Xbox 360", Specifications = "Ta bien pero no tanto", Price = 265, Stock = 5, Available = true, ImageURL = "", PlatformId = 3 }
            );


            modelBuilder.Entity<Videogame>().HasData(
                new Videogame { VideogameId = 1, Name = "Rocket League", Description = "Altos carros voladores", Stock = 3, Pegi = 12, Available = true, Price = 15, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 1, PlatformId = 1, GenderId = 1, Code = "code1" },
                new Videogame { VideogameId = 2, Name = "GTA 5", Description = "Gran Robo de Autos", Stock = 7, Pegi = 18, Available = true, Price = 13, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 1, PlatformId = 2, GenderId = 2, Code = "code2" },
                new Videogame { VideogameId = 3, Name = "The Witcher 3", Description = "Aventura épica en un mundo de fantasía", Stock = 5, Pegi = 18, Available = true, Price = 20, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 2, PlatformId = 3, GenderId = 3, Code = "code3" },
                new Videogame { VideogameId = 4, Name = "Minecraft", Description = "Juego de construcción y aventuras", Stock = 10, Pegi = 7, Available = true, Price = 25, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 3, PlatformId = 1, GenderId = 4, Code = "code4" },
                new Videogame { VideogameId = 5, Name = "Fortnite", Description = "Juego de supervivencia y construcción", Stock = 8, Pegi = 12, Available = true, Price = 0, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 2, PlatformId = 2, GenderId = 5, Code = "code5" },
                new Videogame { VideogameId = 6, Name = "Overwatch", Description = "Juego de disparos en equipo", Stock = 6, Pegi = 12, Available = true, Price = 30, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 1, PlatformId = 3, GenderId = 1, Code = "code6" },
                new Videogame { VideogameId = 7, Name = "FIFA 21", Description = "Simulación de fútbol", Stock = 12, Pegi = 3, Available = true, Price = 50, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 2, PlatformId = 1, GenderId = 2, Code = "code7" },
                new Videogame { VideogameId = 8, Name = "Cyberpunk 2077", Description = "Aventura en un mundo futurista", Stock = 4, Pegi = 18, Available = true, Price = 60, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 3, PlatformId = 2, GenderId = 3, Code = "code8" },
                new Videogame { VideogameId = 9, Name = "Red Dead Redemption 2", Description = "Aventura en el Viejo Oeste", Stock = 9, Pegi = 18, Available = true, Price = 40, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 3, PlatformId = 3, GenderId = 4, Code = "code9" },
                new Videogame { VideogameId = 10, Name = "Assassin's Creed Valhalla", Description = "Aventura de vikingos", Stock = 7, Pegi = 18, Available = true, Price = 55, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 1, PlatformId = 4, GenderId = 5, Code = "code10" },
                new Videogame { VideogameId = 11, Name = "Call of Duty: Modern Warfare", Description = "Juego de disparos en primera persona", Stock = 11, Pegi = 18, Available = true, Price = 50, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 1, PlatformId = 4, GenderId = 1, Code = "code11" },
                new Videogame { VideogameId = 12, Name = "Horizon Zero Dawn", Description = "Aventura en un mundo postapocalíptico", Stock = 5, Pegi = 16, Available = true, Price = 35, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 2, PlatformId = 4, GenderId = 2, Code = "code12" },
                new Videogame { VideogameId = 13, Name = "Stardew Valley", Description = "Simulación de granja", Stock = 8, Pegi = 7, Available = true, Price = 20, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 2, PlatformId = 4, GenderId = 3, Code = "code13" },
                new Videogame { VideogameId = 14, Name = "Among Us", Description = "Juego de deducción social", Stock = 15, Pegi = 10, Available = true, Price = 5, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 2, PlatformId = 1, GenderId = 4, Code = "code14" },
                new Videogame { VideogameId = 15, Name = "The Legend of Zelda: Breath of the Wild", Description = "Aventura en el mundo de Hyrule", Stock = 6, Pegi = 12, Available = true, Price = 60, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png", Requisitos = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", UserId = 3, PlatformId = 2, GenderId = 5, Code = "code15" }
            );

            // modelBuilder.Entity<Videogame>().HasData(
            //     new Videogame { VideogameId = 1, Name = "Rocket League", Description = "Altos carros voladores", Stock = 3, Pegi = 12, Available = true, PlatformId = 1, Price = 15, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp" },
            //     new Videogame { VideogameId = 2, Name = "GTA 5", Description = "Gran Robo de Autos", Stock = 7, Pegi = 18, Available = true, PlatformId = 2, Price = 13, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp" },
            //     new Videogame { VideogameId = 3, Name = "The Witcher 3", Description = "Aventura épica en un mundo de fantasía", Stock = 5, Pegi = 18, Available = true, PlatformId = 1, Price = 20, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp" },
            //     new Videogame { VideogameId = 4, Name = "Minecraft", Description = "Juego de construcción y aventuras",  Stock = 10, Pegi = 7, Available = true, PlatformId = 3, Price = 25, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp" },
            //     new Videogame { VideogameId = 5, Name = "Fortnite", Description = "Juego de supervivencia y construcción",  Stock = 8, Pegi = 12, Available = true, PlatformId = 1, Price = 0, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp" },
            //     new Videogame { VideogameId = 6, Name = "Overwatch", Description = "Juego de disparos en equipo",  Stock = 6, Pegi = 12, Available = true, PlatformId = 2, Price = 30, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp" },
            //     new Videogame { VideogameId = 7, Name = "FIFA 21", Description = "Simulación de fútbol",  Stock = 12, Pegi = 3, Available = true, PlatformId = 3, Price = 50, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp" },
            //     new Videogame { VideogameId = 8, Name = "Cyberpunk 2077", Description = "Aventura en un mundo futurista",  Stock = 4, Pegi = 18, Available = true, PlatformId = 1, Price = 60, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp" },
            //     new Videogame { VideogameId = 9, Name = "Red Dead Redemption 2", Description = "Aventura en el Viejo Oeste",  Stock = 9, Pegi = 18, Available = true, PlatformId = 2, Price = 40, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp" },
            //     new Videogame { VideogameId = 10, Name = "Assassin's Creed Valhalla", Description = "Aventura de vikingos",  Stock = 7, Pegi = 18, Available = true, PlatformId = 3, Price = 55, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp" },
            //     new Videogame { VideogameId = 11, Name = "Call of Duty: Modern Warfare", Description = "Juego de disparos en primera persona",  Stock = 11, Pegi = 18, Available = true, PlatformId = 1, Price = 50, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp" },
            //     new Videogame { VideogameId = 12, Name = "Horizon Zero Dawn", Description = "Aventura en un mundo postapocalíptico",  Stock = 5, Pegi = 16, Available = true, PlatformId = 1, Price = 35, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp" },
            //     new Videogame { VideogameId = 13, Name = "Stardew Valley", Description = "Simulación de granja",  Stock = 8, Pegi = 7, Available = true, PlatformId = 4, Price = 20, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp" },
            //     new Videogame { VideogameId = 14, Name = "Among Us", Description = "Juego de deducción social",  Stock = 15, Pegi = 10, Available = true, PlatformId = 1, Price = 5, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp" },
            //     new Videogame { VideogameId = 15, Name = "The Legend of Zelda: Breath of the Wild", Description = "Aventura en el mundo de Hyrule",  Stock = 6, Pegi = 12, Available = true, PlatformId = 4, Price = 60, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png" }   
            // );

            modelBuilder.Entity<Gender>().HasData(
                new Gender { GenderId = 1, Name = "RPG" },
                new Gender { GenderId = 2, Name = "Shooter" },
                new Gender { GenderId = 3, Name = "Estrategia" },
                new Gender { GenderId = 4, Name = "Accion" },
                new Gender { GenderId = 5, Name = "Deportes" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "COD nuevo", Description = "COD BO4 nuevo en perfectas condiciones", Price = 15, Available = true, ImageURL = "" },
                new Product { ProductId = 2, Name = "Uncharted", Description = "Juego casi nuevo", Price = 10, Available = true, ImageURL = "" },
                new Product { ProductId = 3, Name = "Dark Souls", Description = "Practicamente nuevo", Price = 7, Available = true, ImageURL = "" }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { TransactionId = 1, UserId = 1, ProductId = 1, VideogameId = null, ConsoleId = null, Type = "Compra", Date = DateTime.Now },
                new Transaction { TransactionId = 2, UserId = 2, ProductId = 2, VideogameId = null, ConsoleId = null, Type = "Compra", Date = DateTime.Now },
                new Transaction { TransactionId = 3, UserId = 3, ProductId = 3, VideogameId = null, ConsoleId = null, Type = "Compra", Date = DateTime.Now }
            );


            // modelBuilder.Entity<VideogameGender>().HasData(
            //     new VideogameGender { GenderId = 1, VideogameId = 1 },
            //     new VideogameGender { GenderId = 2, VideogameId = 2 },
            //     new VideogameGender { GenderId = 3, VideogameId = 3 },
            //     new VideogameGender { GenderId = 4, VideogameId = 4 },
            //     new VideogameGender { GenderId = 5, VideogameId = 5 },
            //     new VideogameGender { GenderId = 1, VideogameId = 6 },
            //     new VideogameGender { GenderId = 2, VideogameId = 7 },
            //     new VideogameGender { GenderId = 3, VideogameId = 8 },
            //     new VideogameGender { GenderId = 4, VideogameId = 9 },
            //     new VideogameGender { GenderId = 5, VideogameId = 10 },
            //     new VideogameGender { GenderId = 1, VideogameId = 11 },
            //     new VideogameGender { GenderId = 2, VideogameId = 12 },
            //     new VideogameGender { GenderId = 3, VideogameId = 13 },
            //     new VideogameGender { GenderId = 4, VideogameId = 14 },
            //     new VideogameGender { GenderId = 5, VideogameId = 15 } 
            // );


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<Gender> Genders { get; set; }
        // public DbSet<VideogameGender> VideogameGenders { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Console_> Consoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
