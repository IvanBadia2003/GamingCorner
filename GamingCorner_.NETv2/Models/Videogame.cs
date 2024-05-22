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
    public string Name { get; set; }

    [Required]
    public int Pegi { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public bool Available { get; set; }

    [Required]
    public int PlatformId { get; set; }

    public Platform Platform { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string ImageURL { get; set; }

    public List<VideogameGender> ListVideogameGender { get; set; }

    public List<OrderLine> Order_lines { get; set; } = new List<OrderLine>();


    public Videogame() { }

    public Videogame(string name, int pegi, string description, string category, int stock, bool available, int platformId, decimal price, string imageURL)
    {
        Name = name;
        Pegi = pegi;
        Description = description;
        Category = category;
        Stock = stock;
        Available = available;
        PlatformId = platformId;
        Price = price;
        ImageURL = imageURL;
    }

    public Videogame mapFromCreateDto(VideogameCreateDTO videogameCreateDTO)
    {
        if (videogameCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(videogameCreateDTO));
        }

        var videogame = new Videogame
        {
            Name = videogameCreateDTO.Name,
            Pegi = videogameCreateDTO.Pegi,
            Description = videogameCreateDTO.Description,
            Stock = videogameCreateDTO.Stock,
            Available = videogameCreateDTO.Available,
            PlatformId = videogameCreateDTO.PlatformId,
            Price = videogameCreateDTO.Price,
            ImageURL = videogameCreateDTO.ImageURL
        };

        return videogame;
    }

    // public VideogameDTO MapToDTO()
    // {
    //     var videogameDto = new VideogameDTO
    //     {
    //         VideogameId = this.VideogameId,
    //         Name = this.Name,
    //         Pegi = this.Pegi,
    //         Description = this.Description,
    //         Stock = this.Stock,
    //         Available = this.Available,
    //         Platform = this.Platform,
    //         Price = this.Price,
    //         ImageURL = this.ImageURL,
    //         ListVideogameGender = this.ListVideogameGender.Select(g => new VideogameGenderDTO
    //         {
    //             GenderId = g.GenderId,
    //             VideogameId = g.VideogameId
    //         }).ToList()
    //     };
    //     return videogameDto;
    // }
}