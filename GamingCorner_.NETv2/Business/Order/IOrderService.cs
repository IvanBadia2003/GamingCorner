namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IOrderService
{
    List<OrderDTO> GetAll();
    // GetAll(int id);
    void Add(OrderCreateDTO orderCreateDTO);
    OrderDTO Get(int id);
    void Delete(int id);
}
