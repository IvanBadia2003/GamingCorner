namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class PlatformEFRepository : IPlatformRepository
{


    private readonly GamingCornerContext _context;

    public PlatformEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<PlatformDTO> GetAll()
    {
        var platforms = _context.Platforms
            .ToList();

        if (platforms != null)
        {
            var platformDto = platforms.Select(p => new PlatformDTO
            {
                PlatformId = p.PlatformId,
                Name = p.Name,
            }).ToList();
            return platformDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Platform platform)
    {
        _context.Platforms.Add(platform);
        SaveChanges();
    }

    public PlatformDTO Get(int id)
    {
        var platform = _context.Genders
            .Include(vg => vg.ListVideogameGender)
                .ThenInclude(v => v.Videogame)
            .Where(gender => gender.GenderId == id)
            .FirstOrDefault();

        if (gender != null)
        {
            var genderDto = new GenderDTO
            {
                GenderId = gender.GenderId,
                Name = gender.Name,
                BackgroundImg = gender.BackgroundImg,
                CharacterImg = gender.CharacterImg,
                ListVideogameGender = gender.ListVideogameGender
                    .Where(bo => bo != null && bo.Videogame != null)
                    .Select(bo => new VideogameGenderDTO
                    {
                        VideogameId = bo.VideogameId
                    }).ToList()
            };
            return genderDto;
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

    public void Delete(int id)
    {
        var genderDto = Get(id);
        if (genderDto == null)
        {
            throw new KeyNotFoundException("Gender not found.");
        }
        var gender = _context.Genders.FirstOrDefault(g => g.GenderId == id);
        if (gender != null)
        {
            _context.Genders.Remove(gender);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
