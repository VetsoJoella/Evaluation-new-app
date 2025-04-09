using System ;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using newapp.Services.DashBoardService ;
using newapp.Services.Alert ;
using newapp.Models.Response ;
using newapp.Models ;
using newapp.Services;
using newapp.Services.ImportSrv ;

namespace newapp.Controllers
{
    [Route("Manager")]
    public class ManagerImportController : Controller
    {
        private readonly CheckLogin _checkLogin;
        private readonly IImportService _importService;


        public ManagerImportController(CheckLogin checkLogin, IImportService _importService)
        {
            _checkLogin = checkLogin;
            _importService= _importService;
        }

        [HttpPost("Import")]
        public async Task<IActionResult> Import(IFormFile jsonFile){

            try
            {
                // Vérification du fichier
                if (jsonFile == null || jsonFile.Length == 0)
                {
                    ViewData["Error"] = "Aucun fichier sélectionné.";
                    
                }

                // Vérification de l'extension
                var fileExtension = Path.GetExtension(jsonFile.FileName).ToLower();
                if (fileExtension != ".json")
                {
                    ViewData["Error"] = "Seuls les fichiers JSON (.json) sont acceptés.";
                }

                // Lecture du contenu du fichier
                string fileContent;
                using (var reader = new StreamReader(jsonFile.OpenReadStream()))
                {
                    fileContent = await reader.ReadToEndAsync();
                }

                try
                {
                    ImportService importService = new ImportService() ;
                    ResponseAPI<string> resp = await importService.SendImportData(fileContent);  // ✅ Vérifie bien que await est présent

                    if(resp.Status==200) ViewData["Message"] = resp.Message;
                    if(resp.Status==500) ViewData["Error"] = resp.Error;
                }
                catch (System.Exception ex)
                {
                    ViewData["Error"] = "Erreur de connexion : " + ex.Message;
                }                
                // ViewData["Message"] = "Fichier importé avec succès. Contenu du fichier :";
                // ViewData.FileContent = fileContent; // Stocke le contenu pour l'affichage

            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
            }
            // return RedirectToAction("redirectImport", "Manager");
            return View("~/Views/Manager/Import.cshtml");
           
        }
       

    }

     
}