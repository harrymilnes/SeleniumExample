using Microsoft.AspNetCore.Mvc;

namespace AppExample.Controllers
{
    [Route("api/boolean")]
    public class BooleanApiController : Controller {
 
        [HttpPost("pass-expected/{passExpected}")]
        public IActionResult Get(bool passExpected)
        {
            if (!passExpected)
                return BadRequest();

            return Ok();
        }    
    }
}