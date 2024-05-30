using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IOrderLineRepository
{
    List<OrderLineDTO> GetAll();
    // GetAll(int id);
    void Add(OrderLine orderLine);
    OrderLineDTO Get(int id);
    void Update(OrderLine orderLine);
    void Delete(int id);
}