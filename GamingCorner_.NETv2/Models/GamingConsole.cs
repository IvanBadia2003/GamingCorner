using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class GamingConsole
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ConsoleId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Platform { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public bool Available { get; set; }

    [Required]
    public string? Characteristics { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string? ImageUrl { get; set; }

    // public List<Transaction> transactions { get; set; } = new List<Transaction>();


    public GamingConsole() { }

    public GamingConsole(string name, string platform, int stock, bool available, string characteristics, decimal price, string imageUrl)
    {
        Name = name;
        Platform = platform;
        Stock = stock;
        Available = available;
        Characteristics = characteristics;
        Price = price;
        ImageUrl = imageUrl;
    }
}