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
    public ActionResult<List<TransactionDTO>> GetAll() =>
    _transactionService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<TransactionDTO> Get(int idProduct, int idUser)
    {
        var transaction = _transactionService.Get(idProduct, idUser);

        if (transaction == null){
            return NotFound();
        }else{
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




    // [HttpPut("{id}")]
    // public IActionResult Update(int id, [FromBody] VideogameUpdateDTO videogameUpdateDTO)
    // {
    //     if (!ModelState.IsValid) { return BadRequest(ModelState); }

    //     try
    //     {
    //         _genderService.Update(id, videogameUpdateDTO);
    //         return NoContent();
    //     }
    //     catch (KeyNotFoundException)
    //     {
    //         return NotFound();
    //     }
    // }




    [HttpDelete("{id}")]
    public IActionResult Delete(int idProduct, int idUser)
    {
        var transaction = _transactionService.Get(idProduct, idUser);

        if (transaction is null)
            return NotFound();

        _transactionService.Delete(idProduct, idUser);

        return NoContent();
    }
}