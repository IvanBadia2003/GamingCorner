using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ConsoleCreateDTO
{


    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Specifications { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public bool Available { get; set; }

    [Required]
    public int PlatformId { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string ImageURL { get; set; }


    // public List<Order> Orders { get; set; } = new List<Order>();

}