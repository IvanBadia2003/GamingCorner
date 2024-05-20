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
                new User { UserId = 1, Name = "Diego", Email = "diego@gmail.com", Password = "12345", PhoneNumber = 601112734, Admin = true, ImageURL = "" },
                new User { UserId = 2, Name = "Ivan", Email = "ivan@gmail.com", Password = "12345", PhoneNumber = 123456789, Admin = true, ImageURL = "" },
                new User { UserId = 3, Name = "Adrian", Email = "adrian@gmail.com", Password = "00000", PhoneNumber = 987654321, Admin = false, ImageURL = "" }
            );

            modelBuilder.Entity<Platform>().HasData(
                new Platform { PlatformId = 1, Name = "Steam"},
                new Platform { PlatformId = 2, Name = "Play Station"},
                new Platform { PlatformId = 3, Name = "Xbox"}
            );

            modelBuilder.Entity<Console_>().HasData(
                new Console_ { ConsoleId = 1, Name = "Play Station 4", Specifications = "Ta bien", PlatformId = 2, Price = 300, Stock = 16, Available = true, ImageURL = ""},
                new Console_ { ConsoleId = 1, Name = "Xbox 360", Specifications = "Ta bien pero no tanto", PlatformId = 3, Price = 265, Stock = 5, Available = true, ImageURL = ""}
            );

            modelBuilder.Entity<Videogame>().HasData(
                new Videogame { VideogameId = 1, Name = "Rocket League", Description = "Altos carros voladores", Category = "", Stock = 3, Pegi = 12, Available = true, PlatformId = 1, Price = 15, ImageURL = "" },   
                new Videogame { VideogameId = 2, Name = "GTA 5", Description = "Gran Robo de Autos", Category = "", Stock = 7, Pegi = 18, Available = true, PlatformId = 2, Price = 13, ImageURL = "" }   
            );

            modelBuilder.Entity<Gender>().HasData(
                new Gender { GenderId = 1, Name = "RPG", BackgroundImg = "", CharacterImg = "" },
                new Gender { GenderId = 2, Name = "Shooter", BackgroundImg = "", CharacterImg = "" }
            );

            modelBuilder.Entity<VideogameGender>().HasData(
                new VideogameGender { GenderId = 1, VideogameId = 2 },
                new VideogameGender { GenderId = 2, VideogameId = 1 },
                new VideogameGender { GenderId = 2, VideogameId = 2 }
            );
            

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<VideogameGender> VideogameGenders { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Console_> Consoles { get; set; }
    }
}
