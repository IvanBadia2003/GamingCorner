using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Console_
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ConsoleId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int PlatformId { get; set; }

    public Platform Platform { get; set; }

    [Required]
    public string Specifications { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public bool Available { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string ImageURL { get; set; }

    public List<OrderLine> Order_lines_Console { get; set; } = new List<OrderLine>();


    public Console_() { }

    public Console_(string name,int platformId, string specifications, int stock, bool available, decimal price, string imageURL)
    {
        Name = name;
        PlatformId = platformId;
        Specifications = specifications;
        Stock = stock;
        Available = available;
        Price = price;
        ImageURL = imageURL;
    }

    public Console_ mapFromCreateDto(ConsoleCreateDTO consoleCreateDTO)
    {
        if (consoleCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(consoleCreateDTO));
        }

        var console = new Console_
        {
            Name = consoleCreateDTO.Name,
            PlatformId = consoleCreateDTO.PlatformId,
            Specifications = consoleCreateDTO.Specifications,
            Stock = consoleCreateDTO.Stock,
            Available = consoleCreateDTO.Available,
            Price = consoleCreateDTO.Price,
            ImageURL = consoleCreateDTO.ImageURL
        };

        return console;
    }
}