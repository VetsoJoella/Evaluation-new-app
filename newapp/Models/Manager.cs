using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json.Serialization;

using newapp.Exceptions;
using newapp.Services.Connection ; 
using newapp.Models.Response;

namespace newapp.Models
{
    public class Manager
    {
        // Rendre le champ Name requis avec un message d'erreur personnalisé
        [Required(ErrorMessage = "Name is requires.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        // Rendre le champ Password requis avec un message d'erreur personnalisé
        [Required(ErrorMessage = "Password is required.")]
        [JsonPropertyName("password")]
        public string Password { get; set; }


        public async Task<ResponseAPI<User>> Connection()
        {
            ConnectionService connectionService = new ConnectionService();

            try 
            {
                ResponseAPI<User> responseAPI = await connectionService.Connection(this);

                if (responseAPI == null) throw new ConnectionManagerException("No response from server", this);
                

                if (responseAPI.Status != 200) throw new ConnectionManagerException(responseAPI.Message ?? "Unknown error", this);
                
                return responseAPI ;
            }
            catch (System.Exception ex) 
            {
                Console.WriteLine($"[Connection] Exception levée : {ex.Message}");
                throw;  // ✅ Correct pour garder la stack trace
            }
        }


    }
}
