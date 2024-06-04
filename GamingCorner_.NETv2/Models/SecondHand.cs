using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class SecondHand
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SecondHandId { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public decimal Price { get; set; }


    public SecondHand() { }

    public SecondHand(string title, string description, decimal price)
    {
        Title = title;
        Description = description;
        Price = price;
    }

    public SecondHand mapFromCreateDto(SecondHandCreateDTO secondHandCreateDTO)
    {
        if (secondHandCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(secondHandCreateDTO));
        }

        var secondHand = new SecondHand
        {
            Title = secondHandCreateDTO.Title,
            Description = secondHandCreateDTO.Description,
            Price = secondHandCreateDTO.Price,
            
        };

        return secondHand;
    }

    
}