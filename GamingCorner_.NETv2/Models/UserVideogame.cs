using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class UserVideogame
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User user { get; set; }
    
    [ForeignKey("Videogame")]
    public int VideogameId { get; set; }
    public Videogame videogame{ get; set; }
    public UserVideogame(){}

    public UserVideogame(int userId, int videogameId){
        UserId = userId;
        VideogameId = videogameId;
    }
}