using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace GamingCorner.Models;

public class OrderLine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderLineId { get; set; }

    [ForeignKey("Videogame")]
    public int VideogameId { get; set; }
    [ForeignKey("Console")]
    public int ConsoleId { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public decimal SubtotalPrice { get; set; }
    public int Quantity { get; set; }
    public OrderLine() { }

    public OrderLine(int videogameId, int consoleId, int orderId, decimal subtotalPrice, int quantity)
    {
        VideogameId = videogameId;
        ConsoleId = consoleId;
        OrderId = orderId;
        SubtotalPrice = subtotalPrice;
        Quantity = quantity;
    }

    public OrderLine mapFromCreateDto(OrderLineCreateDTO orderLineCreateDTO)
    {
        if (orderLineCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(orderLineCreateDTO));
        }

        var orderLine = new OrderLine
        {
            VideogameId = orderLineCreateDTO.VideogameId,
            ConsoleId = orderLineCreateDTO.ConsoleId,
            OrderId = orderLineCreateDTO.OrderId,
            SubtotalPrice = orderLineCreateDTO.SubtotalPrice,
            Quantity = orderLineCreateDTO.Quantity
        };

        return orderLine;
    }
}