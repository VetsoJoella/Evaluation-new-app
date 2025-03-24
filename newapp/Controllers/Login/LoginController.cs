using Microsoft.AspNetCore.Mvc;
using System;

using newapp.Exceptions;
using newapp.Models;

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
                    await manager.Connection();  // ✅ Vérifie bien que await est présent
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
