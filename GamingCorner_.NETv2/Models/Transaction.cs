using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Transaction
{
    [ForeignKey("User")]
    public int UserId { get; set; }


    [ForeignKey("Product")]
    public int ProductId { get; set; }

    public User User { get; set; }
    public Product Product { get; set; }


    public Transaction() { }

    public Transaction(int productId, int userId)
    {
        UserId = userId;
        ProductId = productId;
    }

    // public VideogameGender mapFromCreateDto(VideogameGenderCreateDTO videogameGenderCreateDTO)
    // {
    //     if (videogameGenderCreateDTO == null)
    //     {
    //         // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
    //         throw new ArgumentNullException(nameof(videogameGenderCreateDTO));
    //     }

    //     var videogameGender = new VideogameGender
    //     {
    //         GenderId = videogameGenderCreateDTO.GenderId,
    //         VideogameId = videogameGenderCreateDTO.VideogameId,
    //     };

    //     return videogameGender;
    // }
}