using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required]
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public int VideogameId { get; set; }

    [ForeignKey("Videogame")]
    public Videogame Videogame { get; set; }

    public int ConsoleId { get; set; }

    [ForeignKey("Console")]
    public Console_ Console { get; set; }

    public List<Transaction> Transactions { get; set; }

    public Product() { }

    public Product(int videogameId, int consoleId)
    {
        VideogameId = videogameId;
        ConsoleId = consoleId;
        CreationDate = DateTime.Now;
    }

    public Product mapFromCreateDto(ProductCreateDTO productCreateDTO)
    {
        if (productCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(productCreateDTO));
        }

        var product = new Product
        {
           VideogameId = productCreateDTO.VideogameId,
           ConsoleId = productCreateDTO.ConsoleId
        };

        return product;
    }
}