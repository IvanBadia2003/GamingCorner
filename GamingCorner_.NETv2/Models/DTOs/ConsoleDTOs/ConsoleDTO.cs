using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ConsoleDTO
{
    [Key]
    public int ConsoleId { get; set; }

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
    public string? ImageURL { get; set; }

    public List<OrderLine> Order_lines { get; set; } = new List<OrderLine>();

     public Console_ ToConsole()
    {
        return new Console_
        {
            ConsoleId = this.ConsoleId,
            Name = this.Name,
            Specifications = this.Specifications,
            Stock = this.Stock,
            Available = this.Available,
            PlatformId = this.PlatformId,
            ImageURL = this.ImageURL,
        };
    }
}