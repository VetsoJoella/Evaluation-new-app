using Microsoft.AspNetCore.Mvc;
using newapp.Exceptions;
using newapp.Models;
using System;

namespace newapp.Controllers  // IMPORTANT : Ajoute "Login"
{
    [Route("Login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Console.WriteLine("Appel de login ");

            return View();
        }

        [HttpPost("Connection")]
        public IActionResult SubmitForm(Manager manager)
        {
            Console.WriteLine($"Username: {manager.Name}");
            Console.WriteLine($"Password: {manager.Password}");

            if (ModelState.IsValid)
            {
                try {
                    manager.Connection(); // Appel de la méthode qui peut throw une exception

                    return RedirectToAction("Index", "Manager"); // Redirection si la connexion réussit
                } 
                catch (ConnectionManagerException ex) {

                    Console.WriteLine($"Erreur: {ex.Message} | Manager: {ex.ManagerInfo?.Name}");
                    ModelState.AddModelError("", "Erreur de connexion : " + ex.Message);
                    return View(manager); // Retourner la vue avec les champs remplis
                }
                // Traitement de la soumission
                return RedirectToAction("Index", "Manager");                 
            }
            return View("Index", manager);
        }
    }
}
