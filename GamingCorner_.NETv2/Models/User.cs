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
    public string? Email { get; set;}

    [Required]
    public string? Password { get; set;}

    [Required]
    public string? PhoneNumber { get; set;}
    [Required]
    public bool Admin { get; set;}
    [Required]
    public string? URL { get; set; }

    public User(){}

    public User(string name, string email, string password, string phoneNumber,bool admin, string url){
        Name = name;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Admin = admin;
        URL = url;
    }
}