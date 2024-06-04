using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ConsoleOrder
{
    [ForeignKey("Console_")]
    public int ConsoleId { get; set; }


    [ForeignKey("Order")]
    public int OrderId { get; set; }

    public Console_ Console { get; set; }
    public Order Order { get; set; }


    public ConsoleOrder() { }

    public ConsoleOrder(int consoleId, int orderId)
    {
        ConsoleId = consoleId;
        OrderId = orderId;
    }

    public ConsoleOrder mapFromCreateDto(ConsoleOrderCreateDTO consoleOrderCreateDTO)
    {
        if (consoleOrderCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(consoleOrderCreateDTO));
        }

        var consoleOrder = new ConsoleOrder
        {
            ConsoleId = consoleOrderCreateDTO.ConsoleId,
            OrderId = consoleOrderCreateDTO.OrderId,
        };

        return consoleOrder;
    }
}