using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Genre
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GenreId { get; set; }
    
    public string? BackgroundImg { get; set; }

    public string? Name { get; set; }

    public string? CharacterImg { get; set; }

    public List<VideogameGenre> ListVideogameGenre { get; set; }

    public Genre() { }

    public Genre(string backgroundImg, string name, string characterImg)
    {
        BackgroundImg = backgroundImg;
        Name = name;
        CharacterImg = characterImg;
    }
}