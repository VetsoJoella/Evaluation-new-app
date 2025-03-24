using newapp.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using newapp.Models.Response;

namespace newapp.Services.Connection
{
    public class ConnectionService : IConnectionService
    {
        private readonly HttpClient _httpClient;

        public ConnectionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseAPI> Connection(Manager manager)
        {
           try
            {
                // Convertir l'objet User en JSON
                string jsonUser = JsonSerializer.Serialize(manager);
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                Console.WriteLine($"content: {jsonUser}");
                // Envoyer une requête POST
                HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:8080/api/connection", content);


                // Vérifier la réponse
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions{
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    Console.WriteLine($"Réponse de await est : {jsonResponse} ");
                    return JsonSerializer.Deserialize<ResponseAPI>(jsonResponse, options);
                }
                else
                {
                    throw new Exception($"Erreur API : {response.StatusCode}");
                }
                // return null ; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la connexion : {ex.Message}");
                throw ex ;
            }
        }
    }
}
