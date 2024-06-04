using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class VideogameOrder
{
    [ForeignKey("Order")]
    public int OrderId { get; set; }


    [ForeignKey("Videogame")]
    public int VideogameId { get; set; }

    public Order Order { get; set; }
    public Videogame Videogame { get; set; }


    public VideogameOrder() { }

    public VideogameOrder(int orderId, int videogameId)
    {
        OrderId = orderId;
        VideogameId = videogameId;
    }

    public VideogameOrder mapFromCreateDto(VideogameOrderCreateDTO videogameOrderCreateDTO)
    {
        if (videogameOrderCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(videogameOrderCreateDTO));
        }

        var videogameOrder = new VideogameOrder
        {
            OrderId = videogameOrderCreateDTO.OrderId,
            VideogameId = videogameOrderCreateDTO.VideogameId,
        };

        return videogameOrder;
    }
}