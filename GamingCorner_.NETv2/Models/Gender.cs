using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Gender
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GenderId { get; set; }
    
    public string? BackgroundImg { get; set; }

    public string? Name { get; set; }

    public string? CharacterImg { get; set; }

    public List<VideogameGender> ListVideogameGender { get; set; }

    public Gender() { }

    public Gender(string backgroundImg, string name, string characterImg)
    {
        BackgroundImg = backgroundImg;
        Name = name;
        CharacterImg = characterImg;
    }


    public Gender mapFromCreateDto(GenderCreateDTO genderCreateDTO)
    {
        if (genderCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(genderCreateDTO));
        }

        var gender = new Gender
        {
           Name = genderCreateDTO.Name,
           BackgroundImg = genderCreateDTO.BackgroundImg,
           CharacterImg = genderCreateDTO.CharacterImg,
        };

        return gender;
    }
}