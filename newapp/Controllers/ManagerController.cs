using Microsoft.AspNetCore.Mvc;


namespace newapp.Controllers  // IMPORTANT : Ajoute "Login"
{
    [Route("Manager")]
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        [Route("ModifAlertRate")]
        public IActionResult ModifAlertRate()
        {
            return View("Modif-alerte-rate");
        }
    }



}
