namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class PlatformService : IPlatformService
{

    private readonly IPlatformRepository _platformRepository;


    public PlatformService(IPlatformRepository platformRepository)
    {
        _platformRepository = platformRepository;

    }
    public List<GenderDTO> GetAll()
    {
        var genders = _genderRepository.GetAll();
        return genders;
    }

    public GenderDTO Get(int id)
    {
        var gender = _genderRepository.Get(id);
        return gender;
    }


    public void Add(GenderCreateDTO genderCreateDTO)
    {
        var gender = new Gender();
        var mappedGender = gender.mapFromCreateDto(genderCreateDTO);
        _genderRepository.Add(mappedGender);
    }

    // public void Update(int id, VideogameUpdateDTO videogameUpdateDTO)
    // {
    //     var videogameDto = _genderRepository.Get(id);
    //     if(videogameDto == null)
    //     {
    //         throw new KeyNotFoundException($"Videogame con Id {id} no encontrada.");
    //     }

    //     var videogame = videogameDto.ToVideogame();
    //     videogame.Stock = videogameDto.Stock;
    //     videogame.Available = videogameDto.Available;
    //     videogame.Price = videogameDto.Price;
    //     _genderRepository.Update(videogame);
    // }

    public void Delete(int id)
    {
        _genderRepository.Delete(id);
    }
}


    
    

