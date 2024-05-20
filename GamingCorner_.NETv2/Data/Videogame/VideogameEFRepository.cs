namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class VideogameEFRepository : IVideogameRepository
{


    private readonly GamingCornerContext _context;

    public VideogameEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<VideogameDTO> GetAll()
    {
        var videogames = _context.Videogames
            .ToList();

        if (videogames != null)
        {
            var videogameDto = videogames.Select(v => new VideogameDTO
            {
                VideogameId = v.VideogameId,
                Name = v.Name,
                Description = v.Description,
                Pegi = v.Pegi,
                Stock = v.Stock,
                Available = v.Available,
                PlatformId = v.PlatformId,
                Price = v.Price,
                ImageURL = v.ImageURL,
            }).ToList();
            return videogameDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Videogame videogame)
    {
        _context.Videogames.Add(videogame);
        SaveChanges();
    }


    public VideogameDTO Get(int id)
    {
        var videogame = _context.Videogames
            .Include(vg => vg.ListVideogameGender)
                .ThenInclude(g => g.Gender)
            .Where(videogame => videogame.VideogameId == id)
            .FirstOrDefault();

        if (videogame != null)
        {
            var videogameDto = new VideogameDTO
            {
                VideogameId = videogame.VideogameId,
                Name = videogame.Name,
                Description = videogame.Description,
                Pegi = videogame.Pegi,
                Stock = videogame.Stock,
                Available = videogame.Available,
                PlatformId = videogame.PlatformId,
                Price = videogame.Price,
                ImageURL = videogame.ImageURL,
                ListVideogameGender = videogame.ListVideogameGender
                    .Where(bo => bo != null && bo.Gender != null)
                    .Select(bo => new VideogameGenderDTO
                    {
                        GenderId = bo.GenderId
                    }).ToList()
            };

            return videogameDto;
        }
        else
        {
            return null; // Devuelve null si no se encuentra la obra
        }

    }

    public void Update(Videogame videogame)
    {
        var existingVideogame = _context.Videogames.Find(videogame.VideogameId);

        if (existingVideogame != null)
        {
            _context.Entry(existingVideogame).CurrentValues.SetValues(videogame);
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var videogameDto = Get(id);
        if (videogameDto == null)
        {
            throw new KeyNotFoundException("Videogame not found.");
        }
        var videogame = _context.Videogames.FirstOrDefault(v => v.VideogameId == id);
        if (videogame != null)
        {
            _context.Videogames.Remove(videogame);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
