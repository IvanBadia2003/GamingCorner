using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class UserDTO
{
    public int UserId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public int PhoneNumber { get; set; }
  
    [Required]
    public bool Admin { get; set; }
        
    [Required]
    public string? ImageURL { get; set; }
 
    public List<Order> Orders { get; set; } = new List<Order>();

    public UserDTO() { }

    public UserDTO(int userId, string name, string email, string password, int phoneNumber, bool admin, string imageURL)
    {
        UserId = userId;
        Name = name;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Admin = admin;
        ImageURL = imageURL;
    }

     public User ToUser()
    {
        return new User
        {
            UserId = this.UserId,
            Name = this.Name,
            Email = this.Email,
            Password = this.Password,
            PhoneNumber = this.PhoneNumber,
            Admin = this.Admin,
            ImageURL = this.ImageURL
        };
    }
}