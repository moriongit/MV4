using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
