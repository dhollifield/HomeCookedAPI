using Microsoft.AspNetCore.Mvc;
using HomeCooked.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeCooked.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
            private readonly IMealRepository _mealRepository;

            public MealController(IMealRepository mealRepository)
            {
                _mealRepository = mealRepository;
            }
            // GET: api/<MealController>
            [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mealRepository.GetAllMeals());
        }

        // GET api/<MealController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MealController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MealController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MealController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
