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

        public async Task<IActionResult> Index(Intervalle  intervalle)
        {
            if (!_checkLogin.IsAuthenticated())
            {
                Console.WriteLine("Pas authentifié");
                return RedirectToAction("Index", "Login");

            }
            DashBoardService dashBoardService = new DashBoardService();
            try 
            {
                ResponseAPI<DashBoard> responseAPI = await dashBoardService.GetDashBoard();
                ResponseAPI<ExpenseBudgetReport> responseAPI2 = await dashBoardService.GetBudgetReport(intervalle);
                ResponseAPI<List<CustomerContributionItem>> responseAPI3 = await dashBoardService.GetCustomerContribution(intervalle);

                CustomerContribution customerContribution = new CustomerContribution() ;
                customerContribution.Items = responseAPI3.Data ;

                Console.WriteLine($"Valeur somme budget {responseAPI2.Data.SommeBudgetsStr()}, ticket {responseAPI2.Data.SommeTickets}");
                // foreach (var item in customerContribution.Items)
                //     {
                //         Console.WriteLine($"Client: {item.Customer}, " +
                //                         $"Tickets: {item.TicketsContributions}, " +
                //                         $"Leads: {item.LeadsContributions}");
                //     }
                ViewData["Dashboard"] = (DashBoard)responseAPI.Data;
                ViewData["ExpenseBudgetReport"] = responseAPI2.Data ;
                ViewData["CustomerContribution"] = customerContribution ;
                
                return View();
                // if (responseAPI.Status != 200) throw new ConnectionManagerException(responseAPI.Message ?? "Unknown error", this);
                
            }
            catch (System.Exception ex) 
            {
                Console.WriteLine($"[Connection] Exception levée : {ex.Message}");
                throw;  // ✅ Correct pour garder la stack trace
            }
            return View();
        }

        [HttpGet]
        [Route("ModifAlertRate")]

        public async Task<IActionResult> ShowFormAlert() {
            return View("Modif-alerte-rate");
        }


        [HttpPost]
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

        [Route("Import")]
        public IActionResult redirectImport(){


            return View("Import");
        }

        [Route("List")]
        public async Task<IActionResult> List(Intervalle intervalle) {

            Console.WriteLine($"Appel de récupération de liste {intervalle.StartDate} - {intervalle.EndDate} ");
            if (!_checkLogin.IsAuthenticated())
            {
                Console.WriteLine("Pas authentifié");
                return RedirectToAction("Index", "Login");

            }
            DashBoardService dashBoardService = new DashBoardService();

            try
            {
                ResponseAPI<List<MinLeadTicket>> responseAPI = await dashBoardService.GetTickets(intervalle);
                ResponseAPI<List<MinLeadTicket>> responseAPI1 = await dashBoardService.GetLeads(intervalle);

                ViewData["tickets"] = responseAPI.Data;
                ViewData["leads"] = responseAPI1.Data ;

                return View("List");
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }



}
