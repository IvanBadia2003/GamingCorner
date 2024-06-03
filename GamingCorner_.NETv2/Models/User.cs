using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public bool Admin { get; set; }
    [Required]
    public string? ImageURL { get; set; }

    public List<Order> Orders { get; set; } = new List<Order>();

    public User() { }

    public User(string name, string email, string password, string phoneNumber, bool admin, string imageURL)
    {
        Name = name;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Admin = admin;
        ImageURL = imageURL;

    }

    public User mapFromCreateDto(UserCreateDTO userCreateDTO)
    {
        if (userCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(userCreateDTO));
        }

        var user = new User
        {
            Name = userCreateDTO.Name,
            Email = userCreateDTO.Email,
            Password = userCreateDTO.Password,
            Admin = userCreateDTO.Admin,
        };

        return user;
    }

    
}