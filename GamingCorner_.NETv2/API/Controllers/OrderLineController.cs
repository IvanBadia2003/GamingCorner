using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderLineController : ControllerBase
{
    private readonly IOrderLineService _orderLineService;
    public OrderLineController(IOrderLineService orderLineService)
    {
        _orderLineService = orderLineService;
    }

    [HttpGet]
    public ActionResult<List<OrderLineDTO>> GetAll() =>
    _orderLineService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<OrderLineDTO> Get(int id)
    {
        var orderLine = _orderLineService.Get(id);

        if (orderLine == null){
            return NotFound();
        }else{
            return orderLine;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] OrderLineCreateDTO orderLineCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _orderLineService.Add(orderLineCreateDTO);
        return Ok();
    }




    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] OrderLineUpdateDTO orderLineUpdateDTO)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        try
        {
            _orderLineService.Update(id, orderLineUpdateDTO);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }




    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _orderLineService.Get(id);

        if (user is null)
            return NotFound();

        _orderLineService.Delete(id);

        return NoContent();
    }
}