using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class VideogameGender
{
    [ForeignKey("Gender")]
    public int GenderId { get; set; }

    public Gender? Gender { get; set; }

    [ForeignKey("Videogame")]
    public int VideogameId { get; set; }

    public Videogame? Videogame { get; set; }


    public VideogameGender() { }

    public VideogameGender(int genderId, int videogameId)
    {
        GenderId = genderId;
        VideogameId = videogameId;
    }
}