namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IOrderLineService
{
    List<OrderLineDTO> GetAll();
    // GetAll(int id);
    void Add(OrderLineCreateDTO orderLineCreateDTO);
    OrderLineDTO Get(int id);
    void Update(int id, OrderLineUpdateDTO orderLineUpdateDTO);
    void Delete(int id);
}
