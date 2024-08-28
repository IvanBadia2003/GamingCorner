namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class GenderService : IGenderService
{

    private readonly IGenderRepository _genderRepository;


    public GenderService(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;

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


    public void Delete(int id)
    {
        _genderRepository.Delete(id);
    }
}


    
    

