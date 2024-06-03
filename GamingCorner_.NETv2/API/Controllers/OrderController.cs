using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public ActionResult<List<OrderDTO>> GetAll() =>
    _orderService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<OrderDTO> Get(int id)
    {
        var orderLine = _orderService.Get(id);

        if (orderLine == null){
            return NotFound();
        }else{
            return orderLine;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] OrderCreateDTO orderCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _orderService.Add(orderCreateDTO);
        return Ok();
    }




    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _orderService.Get(id);

        if (user is null)
            return NotFound();

        _orderService.Delete(id);

        return NoContent();
    }
}