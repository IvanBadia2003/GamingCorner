using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class VideogameDTO
{
    [Key]
    public int VideogameId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public int Pegi { get; set; }

    [Required]
    public string? Description { get; set; }
  
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
 
    public List<VideogameGenderDTO> ListVideogameGender { get; set; }
    public List<OrderLine> Order_lines_Videogame { get; set; } = new List<OrderLine>();


     public Videogame ToVideogame()
    {
        return new Videogame
        {
            VideogameId = this.VideogameId,
            Name = this.Name,
            Pegi = this.Pegi,
            Description = this.Description,
            Stock = this.Stock,
            Available = this.Available,
            PlatformId = this.PlatformId,
            ImageURL = this.ImageURL,
            ListVideogameGender = this.ListVideogameGender != null ? this.ListVideogameGender.Select(g => new VideogameGender
            {
                Gender = new Gender {GenderId = g.GenderId}
            }).ToList() : null
        }; 
    }
}