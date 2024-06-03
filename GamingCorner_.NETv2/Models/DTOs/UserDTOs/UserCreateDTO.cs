using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class UserCreateDTO
{


    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public bool Admin { get; set; } = false;
    public string? PhoneNumber { get; set; }

    public string? ImageURL { get; set; } // Permitir valores nulos


}