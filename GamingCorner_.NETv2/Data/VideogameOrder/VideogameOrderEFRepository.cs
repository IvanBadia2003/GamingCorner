namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class VideogameOrderEFRepository : IVideogameOrderRepository
{


    private readonly GamingCornerContext _context;

    public VideogameOrderEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<VideogameOrderDTO> GetAll()
    {
        var videogameOrders = _context.VideogameOrders
            .ToList();

        if (videogameOrders != null)
        {
            var videogameOrderDto = videogameOrders.Select(g => new VideogameOrderDTO
            {
                OrderId = g.OrderId,
                VideogameId = g.VideogameId,
            }).ToList();
            return videogameOrderDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(VideogameOrder videogameOrder)
    {
        _context.VideogameOrders.Add(videogameOrder);
        SaveChanges();
    }

    public VideogameOrderDTO Get(int idOrder, int idVideogame)
    {
        var videogameOrder = _context.VideogameOrders
            .Where(vg => vg.OrderId == idOrder && vg.VideogameId == idVideogame)
            .FirstOrDefault();

        if (videogameOrder != null)
        {
            var videogameOrderDto = new VideogameOrderDTO
            {
                OrderId = videogameOrder.OrderId,
                VideogameId = videogameOrder.VideogameId
            };
            return videogameOrderDto;
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

    public void Delete(int idOrder, int idVideogame)
    {
        var videogameOrderDto = Get(idOrder, idVideogame);
        if (videogameOrderDto == null)
        {
            throw new KeyNotFoundException("Videogame Order not found.");
        }
        var videogameOrder = _context.VideogameOrders.FirstOrDefault(g => g.OrderId == idOrder && g.VideogameId == idVideogame) ;
        if (videogameOrder != null)
        {
            _context.VideogameOrders.Remove(videogameOrder);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
