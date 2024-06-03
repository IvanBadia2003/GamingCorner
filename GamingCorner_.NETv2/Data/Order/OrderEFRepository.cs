namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class OrderEFRepository : IOrderRepository
{


    private readonly GamingCornerContext _context;

    public OrderEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<OrderDTO> GetAll()
    {
        var orders = _context.Orders
            .ToList();

        if (orders != null)
        {
            var orderDto = orders.Select(v => new OrderDTO
            {
                OrderId = v.OrderId,
                UserId = v.UserId,
                TotalPrice = v.TotalPrice,
                Date = v.Date,
                BillingAddress = v.BillingAddress,
                Address = v.Address,
            }).ToList();
            return orderDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        SaveChanges();
    }


    public OrderDTO Get(int id)
    {
        var orders = _context.Orders
            .Where(order => order.OrderId == id)
            .FirstOrDefault();

        if (orders != null)
        {
            var orderDto = new OrderDTO
            {
                OrderId = orders.OrderId,
                UserId = orders.UserId,
                TotalPrice = orders.TotalPrice,
                Date = orders.Date,
                BillingAddress = orders.BillingAddress,
                Address = orders.Address,
            };

            return orderDto;
        }
        else
        {
            return null; // Devuelve null si no se encuentra la obra
        }

    }


    public void Delete(int id)
    {
        var orderDto = Get(id);
        if (orderDto == null)
        {
            throw new KeyNotFoundException("Order not found.");
        }
        var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
