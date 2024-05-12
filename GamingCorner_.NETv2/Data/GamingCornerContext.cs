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

            modelBuilder.Entity<VideogameGenre>()
                .HasKey(v => new { v.VideogameId, v.GenreId });

            modelBuilder.Entity<VideogameGenre>()
                .HasOne(v => v.Videogame)
                .WithMany(vl => vl.ListVideogameGenre)
                .HasForeignKey(vli => vli.VideogameId);

            modelBuilder.Entity<VideogameGenre>()
                .HasOne(g => g.Genre)
                .WithMany(vl => vl.ListVideogameGenre)
                .HasForeignKey(vli => vli.GenreId);
            
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

            modelBuilder.Entity<Genre>()
                .HasKey(ge => new { ge.GenreId });


            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Diego", Email = "diego@gmail.com", Password = "12345", PhoneNumber = 601112734, Admin = true, ImageURL = "" },
                new User { UserId = 2, Name = "Ivan", Email = "ivan@gmail.com", Password = "12345", PhoneNumber = 123456789, Admin = true, ImageURL = "" },
                new User { UserId = 3, Name = "Adrian", Email = "adrian@gmail.com", Password = "00000", PhoneNumber = 987654321, Admin = false, ImageURL = "" }
            );
            

        }

        public DbSet<User> Users { get; set; }
    }
}
