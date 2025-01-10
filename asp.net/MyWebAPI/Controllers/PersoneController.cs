using Microsoft.AspNetCore.Mvc;
using Prova_Rubrica.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prova_Rubrica.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PersoneController : ControllerBase
{
    private readonly IService _service;

    public PersoneController(IService service)
    {
        _service = service;
    }


    // GET: api/<PersoneController>
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var listaPersone = await _service.GetPersoneList();
        return Ok(listaPersone);
    }

    // GET api/<PersoneController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<PersoneController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<PersoneController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PersoneController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
