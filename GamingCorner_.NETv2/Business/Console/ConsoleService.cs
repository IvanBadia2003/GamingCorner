namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class ConsoleService : IConsoleService
{

    private readonly IConsoleRepository _consoleRepository;


    public ConsoleService(IConsoleRepository consoleRepository)
    {
        _consoleRepository = consoleRepository;

    }
    public List<ConsoleDTO> GetAll()
    {
        var consoles = _consoleRepository.GetAll();
        return consoles;
    }

    public ConsoleDTO Get(int id)
    {
        var console = _consoleRepository.Get(id);
        return console;
    }


    public void Add(ConsoleCreateDTO consoleCreateDTO)
    {
        var console = new Console_();
        var mappedConsole = console.mapFromCreateDto(consoleCreateDTO);
        _consoleRepository.Add(mappedConsole);
    }

    public void Update(int id, ConsoleUpdateDTO consoleUpdateDTO)
    {
        var consoleDto = _consoleRepository.Get(id);
        if(consoleDto == null)
        {
            throw new KeyNotFoundException($"Consola con Id {id} no encontrada.");
        }

        var console = consoleDto.ToConsole();
        console.Stock = consoleUpdateDTO.Stock;
        console.Available = consoleUpdateDTO.Available;
        console.Price = consoleUpdateDTO.Price;
        _consoleRepository.Update(console);
    }

    public void Delete(int id)
    {
        _consoleRepository.Delete(id);
    }
}


    
    

