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

    public int? VideogameId { get; set; }

    [ForeignKey("Videogame")]
    public Videogame Videogame { get; set; }

    public int? ConsoleId { get; set; }

    [ForeignKey("Console")]
    public Console_ Console { get; set; }

    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    public Product() { }

    // public Product()
    // {

    // }

    // public Product mapFromCreateDto(PlatformCreateDTO platformCreateDTO)
    // {
    //     if (platformCreateDTO == null)
    //     {
    //         // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
    //         throw new ArgumentNullException(nameof(platformCreateDTO));
    //     }

    //     var platform = new Platform
    //     {
    //        Name = platformCreateDTO.Name,
    //     };

    //     return platform;
    // }
}