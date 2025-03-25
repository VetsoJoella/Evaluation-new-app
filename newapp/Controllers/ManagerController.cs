using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using newapp.Services.DashBoardService ;
using newapp.Models.Response ;
using newapp.Models ;

namespace newapp.Controllers  // IMPORTANT : Ajoute "Login"
{
    [Route("Manager")]
    public class ManagerController : Controller
    {
        public async Task<IActionResult> Index()
        {
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
        public IActionResult ModifAlertRate()
        {
            return View("Modif-alerte-rate");
        }
    }



}
