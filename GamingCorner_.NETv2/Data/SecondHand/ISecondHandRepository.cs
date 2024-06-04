using GamingCorner.Models;

namespace GamingCorner.Data;

public interface ISecondHandRepository
{
    List<SecondHandDTO> GetAll();
    // GetAll(int id);
    void Add(SecondHand secondHand);
    SecondHandDTO Get(int idSecondHand);
    // void Update(Gender gender);
    void Delete(int idSecondHand);
}