using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Videogame
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VideogameId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public int Pegi { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public string? Category { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public bool Available { get; set; }

    [Required]
    public string? Platform { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string? URL { get; set; }

    public List<VideogameGenre> ListVideogameGenre { get; set; }
    // public List<Transaction> transactions { get; set; } = new List<Transaction>();


    public Videogame() { }

    public Videogame(string name, int pegi, string description, string category, int stock, bool available, string platform, decimal price, string url)
    {
        Name = name;
        Pegi = pegi;
        Description = description;
        Category = category;
        Stock = stock;
        Available = available;
        Platform = platform;
        Price = price;
        URL = url;
    }
}