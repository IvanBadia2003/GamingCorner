namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IUserService
{
    List<User> GetAll();
    // GetAll(int id);
    void Add(User user);
    User Get(int id);
    void Update(User user);
    void Delete(int id);
}
