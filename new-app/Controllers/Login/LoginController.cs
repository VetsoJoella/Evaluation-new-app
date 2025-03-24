using Microsoft.AspNetCore.Mvc;

namespace newapp.controllers.login  // IMPORTANT : Ajoute "Login"
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
