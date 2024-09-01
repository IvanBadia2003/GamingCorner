using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public ActionResult<List<TransactionDTO>> GetAll() => _transactionService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<TransactionDTO> Get(int id)
    {
        var transaction = _transactionService.Get(id);

        if (transaction == null)
        {
            return NotFound();
        }
        else
        {
            return transaction;
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] TransactionCreateDTO transactionCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _transactionService.Add(transactionCreateDTO);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var transaction = _transactionService.Get(id);

        if (transaction is null)
            return NotFound();

        _transactionService.Delete(id);

        return NoContent();
    }

}





