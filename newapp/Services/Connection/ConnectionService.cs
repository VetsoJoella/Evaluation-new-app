using newapp.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using newapp.Models.Response;
using newapp.Models;
using newapp.Config ; 

namespace newapp.Services.Connection
{
    public class ConnectionService : IConnectionService
    {
        private readonly HttpClient _httpClient;

        public ConnectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ResponseAPI<User>> Connection(Manager manager)
        {
           try
            {
                // Convertir l'objet User en JSON
                string jsonUser = JsonSerializer.Serialize(manager);
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                // Console.WriteLine($"content: {jsonUser}");
                HttpResponseMessage response = await _httpClient.PostAsync(Constant.ApiBaseUrl+"/connection", content);


                // Vérifier la réponse
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions{
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    // Console.WriteLine($"Réponse de await est : {jsonResponse} ");
                    return JsonSerializer.Deserialize<ResponseAPI<User>>(jsonResponse, options);
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
