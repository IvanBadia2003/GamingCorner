namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class UserEFRepository : IUserRepository
{


    private readonly GamingCornerContext _context;

    public UserEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<UserDTO> GetAll()
    {
        var users = _context.Users
            .ToList();

        if (users != null)
        {
            var userDto = users.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Password = u.Password,
                Admin = u.Admin,
                ImageURL = u.ImageURL,
            }).ToList();
            return userDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        SaveChanges();
    }

    public UserDTO Get(int id)
    {
        var user = _context.Users
            .Where(user => user.UserId == id)
            .FirstOrDefault();

        if (user != null)
        {
            var userDto = new UserDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Admin = user.Admin,
                ImageURL = user.ImageURL,
            };
            return userDto;
        }
        else
        {
            return null;
        }
    }

    public void Update(User user)
    {
        var existingUser = _context.Users.Find(user.UserId);

        if (existingUser != null)
        {
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var userDto = Get(id);
        if (userDto == null)
        {
            throw new KeyNotFoundException("User not found.");
        }
        var user = _context.Users.FirstOrDefault(u => u.UserId == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
