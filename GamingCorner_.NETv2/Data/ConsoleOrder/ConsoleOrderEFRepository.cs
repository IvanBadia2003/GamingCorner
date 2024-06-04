namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class ConsoleOrderEFRepository : IConsoleOrderRepository
{


    private readonly GamingCornerContext _context;

    public ConsoleOrderEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<ConsoleOrderDTO> GetAll()
    {
        var consoleOrders = _context.ConsoleOrders
            .ToList();

        if (consoleOrders != null)
        {
            var consoleOrderDto = consoleOrders.Select(g => new ConsoleOrderDTO
            {
                ConsoleId = g.ConsoleId,
                OrderId = g.OrderId,
            }).ToList();
            return consoleOrderDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(ConsoleOrder consoleOrder)
    {
        _context.ConsoleOrders.Add(consoleOrder);
        SaveChanges();
    }

    public ConsoleOrderDTO Get(int idConsole, int idOrder)
    {
        var consoleOrder = _context.ConsoleOrders
            .Where(vg => vg.ConsoleId == idConsole && vg.OrderId == idOrder)
            .FirstOrDefault();

        if (consoleOrder != null)
        {
            var consoleOrderDto = new ConsoleOrderDTO
            {
                ConsoleId = consoleOrder.ConsoleId,
                OrderId = consoleOrder.OrderId
            };
            return consoleOrderDto;
        }
        else
        {
            return null;
        }
    }

    // public void Update(Gender gender)
    // {
    //     var existingGender = _context.Genders.Find(gender.GenderId);

    //     if (existingGender != null)
    //     {
    //         _context.Entry(existingGender).CurrentValues.SetValues(gender);
    //         _context.SaveChanges();
    //     }
    // }

    public void Delete(int idConsole, int idOrder)
    {
        var consoleOrderDto = Get(idConsole, idOrder);
        if (consoleOrderDto == null)
        {
            throw new KeyNotFoundException("Console Order not found.");
        }
        var consoleOrder = _context.ConsoleOrders.FirstOrDefault(g => g.ConsoleId == idConsole && g.OrderId == idOrder) ;
        if (consoleOrder != null)
        {
            _context.ConsoleOrders.Remove(consoleOrder);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
