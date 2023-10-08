using HomeCooked.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeCooked.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {

        private readonly IFuelTypeRepository _fuelTypeRepository;

        public FuelTypeController(IFuelTypeRepository fuelTypeRepository)
        {
            _fuelTypeRepository = fuelTypeRepository;
        }

        // GET: api/<FuelTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fuelTypeRepository.GetFuelTypes());
        }

        // GET api/<FuelTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FuelTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FuelTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FuelTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
