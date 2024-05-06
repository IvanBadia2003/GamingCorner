namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;


    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;

    }
    public List<User> GetAll()
    {
        var users = _userRepository.GetAll();
        return users;
    }

    public User Get(int id)
    {
        var user = _userRepository.Get(id);

        // if (pizza != null)
        // {
        //     pizza.Ingredientes = _ingredientesRepository.GetIngredientesByPizzaId(pizza.Id);
        // }

        return user;
    }


    public void Add(User user)
    {
        _userRepository.Add(user);

        // foreach (var ingrediente in pizza.Ingredientes)
        // {
        //     _ingredientesRepository.AddIngredienteToPizza(ingrediente, pizza.Id);
        // }
    }

    public void Update(User user)
    {
        _userRepository.Update(user);

        // _ingredientesRepository.UpdateIngredientesForPizza(pizza.Ingredientes, pizza.Id);
    }

    public void Delete(int id)
    {
        _userRepository.Delete(id);
    }
}


    
    

