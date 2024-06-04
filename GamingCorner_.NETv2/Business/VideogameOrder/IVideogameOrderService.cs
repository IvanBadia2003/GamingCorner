namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IVideogameOrderService
{
    List<VideogameOrderDTO> GetAll();
    // GetAll(int id);
    void Add(VideogameOrderCreateDTO videogameOrderCreateDTO);
    VideogameOrderDTO Get(int idOrder, int idVideogame);
    void Delete(int idOrder, int idVideogame);
}
