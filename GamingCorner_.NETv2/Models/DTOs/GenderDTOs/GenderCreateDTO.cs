using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class GenderCreateDTO
{


     public string? BackgroundImg { get; set; }

    public string? Name { get; set; }

    public string? CharacterImg { get; set; }
}