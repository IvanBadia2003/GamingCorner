namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class OrderLineEFRepository : IOrderLineRepository
{


    private readonly GamingCornerContext _context;

    public OrderLineEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<OrderLineDTO> GetAll()
    {
        var orderLines = _context.OrderLines
            .ToList();

        if (orderLines != null)
        {
            var orderLineDto = orderLines.Select(v => new OrderLineDTO
            {
                VideogameId = v.VideogameId,
                ConsoleId = v.ConsoleId,
                OrderId = v.OrderId,
                Quantity = v.Quantity,
                SubtotalPrice = v.SubtotalPrice,
            }).ToList();
            return orderLineDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(OrderLine orderLine)
    {
        _context.OrderLines.Add(orderLine);
        SaveChanges();
    }


    public OrderLineDTO Get(int id)
    {
        var orderLine = _context.OrderLines
            .Where(orderLine => orderLine.OrderLineId == id)
            .FirstOrDefault();

        if (orderLine != null)
        {
            var orderLineDto = new OrderLineDTO
            {
                VideogameId = orderLine.VideogameId,
                ConsoleId = orderLine.ConsoleId,
                OrderId = orderLine.OrderId,
                Quantity = orderLine.Quantity,
                SubtotalPrice = orderLine.SubtotalPrice,
            };

            return orderLineDto;
        }
        else
        {
            return null; // Devuelve null si no se encuentra la obra
        }

    }

    public void Update(OrderLine orderLine)
    {
        var existingOrderLine = _context.OrderLines.Find(orderLine.OrderId);

        if (existingOrderLine != null)
        {
            _context.Entry(existingOrderLine).CurrentValues.SetValues(orderLine);
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var orderLineDto = Get(id);
        if (orderLineDto == null)
        {
            throw new KeyNotFoundException("Order Line not found.");
        }
        var orderLine = _context.OrderLines.FirstOrDefault(ol => ol.OrderLineId == id);
        if (orderLine != null)
        {
            _context.OrderLines.Remove(orderLine);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
