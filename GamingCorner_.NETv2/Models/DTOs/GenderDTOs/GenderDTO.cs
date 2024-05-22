using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class GenderDTO
{
    [Key]
    public int GenderId { get; set; }
    
    public string? BackgroundImg { get; set; }

    public string? Name { get; set; }

    public string? CharacterImg { get; set; }

    public List<VideogameGenderDTO> ListVideogameGender { get; set; }


     public Gender ToGenre()
    {
        return new Gender
        {
            GenderId = this.GenderId,
            Name = this.Name,
            CharacterImg = this.CharacterImg,
            BackgroundImg = this.BackgroundImg,
            ListVideogameGender = this.ListVideogameGender != null ? this.ListVideogameGender.Select(g => new VideogameGender
            {
                Videogame = new Videogame {VideogameId = g.VideogameId}
            }).ToList() : null
        };
    }
}