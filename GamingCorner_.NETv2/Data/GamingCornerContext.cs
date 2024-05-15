using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GamingCorner.Models;
using System.Security.Cryptography.X509Certificates;

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

            modelBuilder.Entity<Videogame>().HasData(
                new Videogame { VideogameId = 1, Name = "Rocket League", Description = "Altos carros voladores", Category = "", Stock = 3, Pegi = 12, Available = true, Platform = "Steam", Price = 15, ImageURL = "" },   
                new Videogame { VideogameId = 2, Name = "GTA 5", Description = "Gran Robo de Autos", Category = "", Stock = 7, Pegi = 18, Available = true, Platform = "Play Station", Price = 13, ImageURL = "" }   
            );

            modelBuilder.Entity<Gender>().HasData(
                new Gender { GenderId = 1, Name = "RPG", BackgroundImg = "", CharacterImg = "" },
                new Gender { GenderId = 2, Name = "Shooter", BackgroundImg = "", CharacterImg = "" }
            );
            

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<Gender> Genders { get; set; }
    }
}
