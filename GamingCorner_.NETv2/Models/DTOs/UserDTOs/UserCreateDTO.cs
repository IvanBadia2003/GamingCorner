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

  
    [Required]
    public bool Admin { get; set; }
 
    public List<Order> Orders { get; set; } = new List<Order>();

    public UserCreateDTO() { }

    public UserCreateDTO(string name, string email, string password, bool admin)
    {
        Name = name;
        Email = email;
        Password = password;
        Admin = admin;
    }
}