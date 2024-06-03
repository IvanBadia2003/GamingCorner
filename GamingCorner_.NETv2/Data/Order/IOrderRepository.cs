using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IOrderRepository
{
    List<OrderDTO> GetAll();
    // GetAll(int id);
    void Add(Order order);
    OrderDTO Get(int id);
    void Delete(int id);
}