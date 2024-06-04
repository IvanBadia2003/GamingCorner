using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IVideogameOrderRepository
{
    List<VideogameOrderDTO> GetAll();
    // GetAll(int id);
    void Add(VideogameOrder videogameOrder);
    VideogameOrderDTO Get(int idOrder, int idVideogame);
    // void Update(Gender gender);
    void Delete(int idOrder, int idVideogame);
}