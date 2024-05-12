using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class VideogameGenre
{
    [ForeignKey("Genre")]
    public int GenreId { get; set; }

    public Genre? Genre { get; set; }

    [ForeignKey("Videogame")]
    public int VideogameId { get; set; }

    public Videogame? Videogame { get; set; }


    public VideogameGenre() { }

    public VideogameGenre(int genreId, int videogameId)
    {
        GenreId = genreId;
        VideogameId = videogameId;
    }
}