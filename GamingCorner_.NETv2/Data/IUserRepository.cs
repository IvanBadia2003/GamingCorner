using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IUserRepository
{
    List<User> GetAll();
    // GetAll(int id);
    void Add(User user);
    User Get(int id);
    void Update(User user);
    void Delete(int id);
}