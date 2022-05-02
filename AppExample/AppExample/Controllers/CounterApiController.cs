using Microsoft.AspNetCore.Mvc;

namespace AppExample.Controllers
{
    [Route("api/counter")]
    public class CounterApiController : Controller {
 
        [HttpPost("increment/{currentNumber}")]
        public IActionResult Get(int currentNumber)
        {
            var incrementedNumber = currentNumber+1;
            return Ok(incrementedNumber);
        }    
    }
}