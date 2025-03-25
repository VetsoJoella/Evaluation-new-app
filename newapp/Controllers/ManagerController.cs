using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http; 

using newapp.Services.DashBoardService ;
using newapp.Services.Alert ;
using newapp.Models.Response ;
using newapp.Models ;
using newapp.Services;


namespace newapp.Controllers  // IMPORTANT : Ajoute "Login"
{
    [Route("Manager")]
    public class ManagerController : Controller
    {
        private readonly CheckLogin _checkLogin;
        
         public ManagerController(CheckLogin checkLogin)
        {
            _checkLogin = checkLogin;
        }

        public async Task<IActionResult> Index()
        {
            if (!_checkLogin.IsAuthenticated())
            {
                return RedirectToAction("Index", "Login");

            }
            DashBoardService dashBoardService = new DashBoardService();
            try 
            {
                ResponseAPI<DashBoard> responseAPI = await dashBoardService.GetDashBoard();
                Console.WriteLine("Données " +responseAPI.Data);

                return View((DashBoard)responseAPI.Data);
                // if (responseAPI.Status != 200) throw new ConnectionManagerException(responseAPI.Message ?? "Unknown error", this);
                
            }
            catch (System.Exception ex) 
            {
                Console.WriteLine($"[Connection] Exception levée : {ex.Message}");
                throw;  // ✅ Correct pour garder la stack trace
            }
            return View();
        }

        
        [Route("ModifAlertRate")]
        public async Task<IActionResult> ModifAlertRate(AlertRate alertRate)
        {
            if (!_checkLogin.IsAuthenticated())
            {
                return RedirectToAction("Index", "Login");

            }
            if (ModelState.IsValid)
            {
                Console.WriteLine($"Alert Rate: {alertRate.EndDate}, {alertRate.StartDate}, {alertRate.Percentage}");
                AlertService alertService = new AlertService() ;
                ResponseAPI<Dictionary<string, object>> response = await alertService.SendAlert(alertRate) ;

                if(response.Message!=null) {
                    ViewData["Message"] = "Data inserted";
                } else ViewData["Error"] = "Data not inserted";
            } 
            else ViewData["Error"] = "Data not inserted";
            return View("Modif-alerte-rate");

        }
    }



}
