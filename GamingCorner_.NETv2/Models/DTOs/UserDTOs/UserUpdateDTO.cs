using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace GamingCorner.Models;

public class UserUpdateDTO
{


    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public int PhoneNumber { get; set; }

    public string? ImageURL { get; set; }

    public UserUpdateDTO() { }

    public UserUpdateDTO(string name, string email, string password, int phoneNumber, string imageURL)
    {
        Name = name;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        ImageURL = imageURL;
    }
}