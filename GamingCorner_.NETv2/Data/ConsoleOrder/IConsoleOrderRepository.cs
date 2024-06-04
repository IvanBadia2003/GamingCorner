using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IConsoleOrderRepository
{
    List<ConsoleOrderDTO> GetAll();
    // GetAll(int id);
    void Add(ConsoleOrder consoleOrder);
    ConsoleOrderDTO Get(int idConsole, int idOrder);
    // void Update(Gender gender);
    void Delete(int idGender, int idVideogame);
}