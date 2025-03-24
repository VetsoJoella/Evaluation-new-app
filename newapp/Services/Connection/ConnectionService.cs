using newapp.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace newapp.Services.Connection
{
    public class ConnectionService : IConnectionService
    {
        private readonly HttpClient _httpClient;

        public ConnectionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Manager> Connection(Manager manager)
        {
           try
            {
                // Convertir l'objet User en JSON
                string jsonUser = JsonSerializer.Serialize(user);
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                // Envoyer une requête POST
                HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:8080/connection", content);

                // Vérifier la réponse
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Manager>(jsonResponse);
                }
                else
                {
                    throw new Exception($"Erreur API : {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la connexion : {ex.Message}");
                return null;
            }
        }
    }
}
