using Microsoft.AspNetCore.Mvc;
using Prova_Rubrica.Models;
using Prova_Rubrica.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prova_Rubrica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeriUtiliController : ControllerBase
    {
        private readonly IService _service;

        public NumeriUtiliController(IService service) 
        {
            _service = service;
        }
        // GET: api/<NumeriUtiliController>
        [HttpGet("GetAll")]
        public async Task<IActionResult>GetAll()
        {
            var listaNumeriUtili = await _service.GetNumeriList();
            return Ok(listaNumeriUtili);
        }

        // GET api/<NumeriUtiliController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NumeriUtiliController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NumeriUtiliController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NumeriUtiliController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
