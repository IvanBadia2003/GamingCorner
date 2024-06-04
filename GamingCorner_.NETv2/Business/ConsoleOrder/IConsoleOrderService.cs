namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IConsoleOrderService
{
    List<ConsoleOrderDTO> GetAll();
    // GetAll(int id);
    void Add(ConsoleOrderCreateDTO consoleOrderCreateDTO);
    ConsoleOrderDTO Get(int idConsole, int idOrder);
    void Delete(int idConsole, int idOrder);
}
