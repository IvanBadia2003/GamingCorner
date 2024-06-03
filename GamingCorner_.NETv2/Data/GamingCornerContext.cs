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

            modelBuilder.Entity<VideogameGender>()
                .HasKey(v => new { v.VideogameId, v.GenderId });

            modelBuilder.Entity<VideogameGender>()
                .HasOne(v => v.Videogame)
                .WithMany(vl => vl.ListVideogameGender)
                .HasForeignKey(vli => vli.VideogameId);

            modelBuilder.Entity<VideogameGender>()
                .HasOne(g => g.Gender)
                .WithMany(vl => vl.ListVideogameGender)
                .HasForeignKey(vli => vli.GenderId);
            
            modelBuilder.Entity<Order>()
                .HasOne(u => u.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(u => u.UserId );

            modelBuilder.Entity<Videogame>()
                .HasOne (p => p.Platform)
                .WithMany(v => v.videogames)
                .HasForeignKey(p => p.PlatformId);

            modelBuilder.Entity<User>()
                .HasKey(u => new { u.UserId });

            modelBuilder.Entity<Videogame>()
                .HasKey(v => new { v.VideogameId });
            
            modelBuilder.Entity<GamingConsole>()
                .HasKey(c => new { c.ConsoleId });

            modelBuilder.Entity<Platform>()
                .HasKey(p => new { p.PlatformId });

            modelBuilder.Entity<Order>()
                .HasKey(or => new { or.OrderId });

            modelBuilder.Entity<OrderLine>()
                .HasKey(ol => new { ol.OrderLineId });

            modelBuilder.Entity<Gender>()
                .HasKey(ge => new { ge.GenderId });


            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Diego", Email = "diego@gmail.com", Password = "12345", PhoneNumber = "601112734", Admin = true, ImageURL = ""},
                new User { UserId = 2, Name = "Ivan", Email = "ivan@gmail.com", Password = "12345", PhoneNumber = "123456789", Admin = true, ImageURL = ""},
                new User { UserId = 3, Name = "Adrian", Email = "adrian@gmail.com", Password = "00000", PhoneNumber = "987654321", Admin = false, ImageURL = ""}
            );

            modelBuilder.Entity<Platform>().HasData(
                new Platform { PlatformId = 1, Name = "Steam"},
                new Platform { PlatformId = 2, Name = "Play Station"},
                new Platform { PlatformId = 3, Name = "Xbox"},
                new Platform { PlatformId = 4, Name = "Switch"}
            );

            modelBuilder.Entity<Console_>().HasData(
                new Console_ { ConsoleId = 1, Name = "Play Station 4", Specifications = "Ta bien", PlatformId = 2, Price = 300, Stock = 16, Available = true, ImageURL = ""},
                new Console_ { ConsoleId = 2, Name = "Xbox 360", Specifications = "Ta bien pero no tanto", PlatformId = 3, Price = 265, Stock = 5, Available = true, ImageURL = ""}
            );

            modelBuilder.Entity<Videogame>().HasData(
                new Videogame { VideogameId = 1, Name = "Rocket League", Description = "Altos carros voladores", Stock = 3, Pegi = 12, Available = true, PlatformId = 1, Price = 15, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp" },
                new Videogame { VideogameId = 2, Name = "GTA 5", Description = "Gran Robo de Autos", Stock = 7, Pegi = 18, Available = true, PlatformId = 2, Price = 13, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp" },
                new Videogame { VideogameId = 3, Name = "The Witcher 3", Description = "Aventura épica en un mundo de fantasía", Stock = 5, Pegi = 18, Available = true, PlatformId = 1, Price = 20, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp" },
                new Videogame { VideogameId = 4, Name = "Minecraft", Description = "Juego de construcción y aventuras",  Stock = 10, Pegi = 7, Available = true, PlatformId = 3, Price = 25, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp" },
                new Videogame { VideogameId = 5, Name = "Fortnite", Description = "Juego de supervivencia y construcción",  Stock = 8, Pegi = 12, Available = true, PlatformId = 1, Price = 0, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp" },
                new Videogame { VideogameId = 6, Name = "Overwatch", Description = "Juego de disparos en equipo",  Stock = 6, Pegi = 12, Available = true, PlatformId = 2, Price = 30, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp" },
                new Videogame { VideogameId = 7, Name = "FIFA 21", Description = "Simulación de fútbol",  Stock = 12, Pegi = 3, Available = true, PlatformId = 3, Price = 50, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp" },
                new Videogame { VideogameId = 8, Name = "Cyberpunk 2077", Description = "Aventura en un mundo futurista",  Stock = 4, Pegi = 18, Available = true, PlatformId = 1, Price = 60, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp" },
                new Videogame { VideogameId = 9, Name = "Red Dead Redemption 2", Description = "Aventura en el Viejo Oeste",  Stock = 9, Pegi = 18, Available = true, PlatformId = 2, Price = 40, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp" },
                new Videogame { VideogameId = 10, Name = "Assassin's Creed Valhalla", Description = "Aventura de vikingos",  Stock = 7, Pegi = 18, Available = true, PlatformId = 3, Price = 55, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp" },
                new Videogame { VideogameId = 11, Name = "Call of Duty: Modern Warfare", Description = "Juego de disparos en primera persona",  Stock = 11, Pegi = 18, Available = true, PlatformId = 1, Price = 50, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp" },
                new Videogame { VideogameId = 12, Name = "Horizon Zero Dawn", Description = "Aventura en un mundo postapocalíptico",  Stock = 5, Pegi = 16, Available = true, PlatformId = 1, Price = 35, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp" },
                new Videogame { VideogameId = 13, Name = "Stardew Valley", Description = "Simulación de granja",  Stock = 8, Pegi = 7, Available = true, PlatformId = 4, Price = 20, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp" },
                new Videogame { VideogameId = 14, Name = "Among Us", Description = "Juego de deducción social",  Stock = 15, Pegi = 10, Available = true, PlatformId = 1, Price = 5, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp" },
                new Videogame { VideogameId = 15, Name = "The Legend of Zelda: Breath of the Wild", Description = "Aventura en el mundo de Hyrule",  Stock = 6, Pegi = 12, Available = true, PlatformId = 4, Price = 60, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png" }   
            );

            modelBuilder.Entity<Gender>().HasData(
                new Gender { GenderId = 1, Name = "RPG", BackgroundImg = "", CharacterImg = "" },
                new Gender { GenderId = 2, Name = "Shooter", BackgroundImg = "", CharacterImg = "" },
                new Gender { GenderId = 3, Name = "Estrategia", BackgroundImg = "", CharacterImg = "" },
                new Gender { GenderId = 4, Name = "Accion", BackgroundImg = "", CharacterImg = "" },
                new Gender { GenderId = 5, Name = "Deportes", BackgroundImg = "", CharacterImg = "" }
            );

            modelBuilder.Entity<VideogameGender>().HasData(
                new VideogameGender { GenderId = 1, VideogameId = 1 },
                new VideogameGender { GenderId = 2, VideogameId = 2 },
                new VideogameGender { GenderId = 3, VideogameId = 3 },
                new VideogameGender { GenderId = 4, VideogameId = 4 },
                new VideogameGender { GenderId = 5, VideogameId = 5 },
                new VideogameGender { GenderId = 1, VideogameId = 6 },
                new VideogameGender { GenderId = 2, VideogameId = 7 },
                new VideogameGender { GenderId = 3, VideogameId = 8 },
                new VideogameGender { GenderId = 4, VideogameId = 9 },
                new VideogameGender { GenderId = 5, VideogameId = 10 },
                new VideogameGender { GenderId = 1, VideogameId = 11 },
                new VideogameGender { GenderId = 2, VideogameId = 12 },
                new VideogameGender { GenderId = 3, VideogameId = 13 },
                new VideogameGender { GenderId = 4, VideogameId = 14 },
                new VideogameGender { GenderId = 5, VideogameId = 15 } 
            );
            

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<VideogameGender> VideogameGenders { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Console_> Consoles { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
