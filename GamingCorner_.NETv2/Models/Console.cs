using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Console
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
    public string? URL { get; set; }

    public Console(){}

    public Console(string name,  string platform, int stock, bool available, string characteristics, decimal price, string url){
        Name = name;
        Platform = platform;
        Stock = stock;
        Available = available;
        Characteristics = characteristics;
        Price = price;
        URL = url;
    }
}