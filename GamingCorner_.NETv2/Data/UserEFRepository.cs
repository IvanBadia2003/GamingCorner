namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;


{

    public class UserEFRepository : IUserRepository
    {


        private readonly GamingCornerContext _context;

        public UserEFRepository(GamingCornerContext context)
        {

            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
            // var pizzas = _context.Pizzas
            //     .Include(p => p.PizzaIngredientes)
            //         .ThenInclude(pi => pi.Ingrediente)
            //     .ToList();

            // var pizzasDto = pizzas.Select(p => new PizzaDto
            // {
            //     Id = p.Id,
            //     Name = p.Name,
            //     PizzaIngredientes = p.PizzaIngredientes.Select(pi => new IngredienteDto
            //     {
            //         Id = pi.Ingrediente.Id,
            //         Name = pi.Ingrediente.Name
            //     }).ToList()
            // }).ToList();

            // return pizzasDto;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(user => user.UserId == id);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var user = Get(id);
            if (user is null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            _context.Users.Remove(user);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }

}