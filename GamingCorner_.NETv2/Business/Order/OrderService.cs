namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class OrderService : IOrderService
{

    private readonly IOrderRepository _orderRepository;


    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;

    }
    public List<OrderDTO> GetAll()
    {
        var orderLines = _orderRepository.GetAll();
        return orderLines;
    }

    public OrderDTO Get(int id)
    {
        var orderLine = _orderRepository.Get(id);
        return orderLine;
    }


    public void Add(OrderCreateDTO orderCreateDTO)
    {
        var order = new Order();
        var mappedOrder = order.mapFromCreateDto(orderCreateDTO);
        _orderRepository.Add(mappedOrder);
    }

    public void Delete(int id)
    {
        _orderRepository.Delete(id);
    }
}


    
    

