using Microsoft.AspNetCore.Mvc;

namespace AppExample.Controllers
{
    public class CounterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}