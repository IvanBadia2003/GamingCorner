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
    public string Code { get; set; }

    [Required]
    public string? Description { get; set; }
    
    [Required]
    public User User { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public string? Requisitos { get; set; }

    [Required]
    public int Stock { get; set; }
  
    [Required]
    public bool Available { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public int PlatformId { get; set; }
    
    [Required]
    public int GenderId { get; set; }
        
    [Required]
    public string? ImageURL { get; set; }
 

     public Videogame ToVideogame()
    {
        return new Videogame
        {
            VideogameId = this.VideogameId,
            Name = this.Name,
            Price = this.Price,
            Description = this.Description,
            Requisitos = this.Requisitos,
            Stock = this.Stock,
            Available = this.Available,
            Pegi = this.Pegi,
            PlatformId = this.PlatformId,
            GenderId = this.GenderId,
            ImageURL = this.ImageURL
        };
    }
}