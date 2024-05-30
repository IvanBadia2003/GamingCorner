namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class OrderLineService : IOrderLineService
{

    private readonly IOrderLineRepository _orderLineRepository;


    public OrderLineService(IOrderLineRepository orderLineRepository)
    {
        _orderLineRepository = orderLineRepository;

    }
    public List<OrderLineDTO> GetAll()
    {
        var orderLines = _orderLineRepository.GetAll();
        return orderLines;
    }

    public OrderLineDTO Get(int id)
    {
        var orderLine = _orderLineRepository.Get(id);
        return orderLine;
    }


    public void Add(OrderLineCreateDTO orderLineCreateDTO)
    {
        var orderLine = new OrderLine();
        var mappedOrderLine = orderLine.mapFromCreateDto(orderLineCreateDTO);
        _orderLineRepository.Add(mappedOrderLine);
    }

    public void Update(int id, OrderLineUpdateDTO orderLineUpdateDTO)
    {
        var orderLineDto = _orderLineRepository.Get(id);
        if(orderLineDto == null)
        {
            throw new KeyNotFoundException($"Order Line con Id {id} no encontrada.");
        }

        var orderLine = orderLineDto.ToVideogame();
        orderLine.Quantity = orderLineUpdateDTO.Quantity;
        orderLine.SubtotalPrice = orderLineUpdateDTO.SubtotalPrice;
        _orderLineRepository.Update(orderLine);
    }

    public void Delete(int id)
    {
        _orderLineRepository.Delete(id);
    }
}


    
    

