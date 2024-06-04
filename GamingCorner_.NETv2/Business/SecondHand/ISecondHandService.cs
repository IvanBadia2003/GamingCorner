namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface ISecondHandService
{
    List<SecondHandDTO> GetAll();
    // GetAll(int id);
    void Add(SecondHandCreateDTO secondHandCreateDTO);
    SecondHandDTO Get(int idSecondHand);
    void Delete(int idSecondHand);
}
