using HomeCooked.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeCooked.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMealController : ControllerBase
    {
        private readonly IUserMealRepository _userMealRepository;

        public UserMealController(IUserMealRepository userMealRepository)
        {
            _userMealRepository= userMealRepository;
        }

        // GET: api/<UserMealController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserMealController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, DateTime today)
        {
            var userMeal = _userMealRepository.GetAllUserMeals(id, today);

            if (userMeal == null)
            {
                return NotFound();
            }
            return Ok(userMeal);
        }

        // POST api/<UserMealController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserMealController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserMealController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
