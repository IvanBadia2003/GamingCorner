namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class ConsoleEFRepository : IConsoleRepository
{


    private readonly GamingCornerContext _context;

    public ConsoleEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<ConsoleDTO> GetAll()
    {
        var consoles = _context.Consoles
            .ToList();

        if (consoles != null)
        {
            var consoleDto = consoles.Select(v => new ConsoleDTO
            {
                ConsoleId = v.ConsoleId,
                Name = v.Name,
                Specifications = v.Specifications,
                Stock = v.Stock,
                Available = v.Available,
                PlatformId = v.PlatformId,
                Price = v.Price,
                ImageURL = v.ImageURL,
            }).ToList();
            return consoleDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Console_ console)
    {
        _context.Consoles.Add(console);
        SaveChanges();
    }


    public ConsoleDTO Get(int id)
    {
        var console = _context.Consoles
            .Where(c => c.ConsoleId == id)
            .FirstOrDefault();
            // .Include(vg => vg.ListVideogameGender)
            //     .ThenInclude(g => g.Gender)
            // .Where(videogame => videogame.VideogameId == id)
            // .FirstOrDefault();

        if (console != null)
        {
            var consoleDto = new ConsoleDTO
            {
                ConsoleId = console.ConsoleId,
                Name = console.Name,
                Specifications = console.Specifications,
                Stock = console.Stock,
                Available = console.Available,
                PlatformId = console.PlatformId,
                Price = console.Price,
                ImageURL = console.ImageURL,
                // ListVideogameGender = videogame.ListVideogameGender
                //     .Where(bo => bo != null && bo.Gender != null)
                //     .Select(bo => new VideogameGenderDTO
                //     {
                //         GenderId = bo.GenderId
                //     }).ToList()
            };

            return consoleDto;
        }
        else
        {
            return null; // Devuelve null si no se encuentra la obra
        }

    }

    public void Update(Console_ console)
    {
        var existingConsole = _context.Consoles.Find(console.ConsoleId);

        if (existingConsole != null)
        {
            _context.Entry(existingConsole).CurrentValues.SetValues(console);
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var consoleDto = Get(id);
        if (consoleDto == null)
        {
            throw new KeyNotFoundException("Console not found.");
        }
        var console = _context.Consoles.FirstOrDefault(c => c.ConsoleId == id);
        if (console != null)
        {
            _context.Consoles.Remove(console);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
