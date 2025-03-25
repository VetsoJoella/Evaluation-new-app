using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http; 

using newapp.Exceptions;
using newapp.Models;
using newapp.Models.Response;

namespace newapp.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost("Connection")]
        public async Task<IActionResult> SubmitForm(Manager manager)
        {
            
            Console.WriteLine($"[SubmitForm] Début - Username: {manager.Name}");

            if (ModelState.IsValid)
            {
                try
                {
                    ResponseAPI<User> resp = await manager.Connection();  // ✅ Vérifie bien que await est présent
                    HttpContext.Session.SetInt32("user", resp.Data.Id);
                    return RedirectToAction("Index", "Manager");
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("", "Erreur de connexion : " + ex.Message);
                    return View("Index", manager);
                }
            }
            return View("Index", manager);
        }


    }
}
