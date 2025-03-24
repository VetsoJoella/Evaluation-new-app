using Microsoft.AspNetCore.Mvc;

namespace newapp.Controllers  // IMPORTANT : Ajoute "Login"
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
