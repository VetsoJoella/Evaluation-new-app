using newapp.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

using newapp.Models.Response;
using newapp.Models;
using newapp.Config ; 

namespace newapp.Services.Alert
{
    public class AlertService : IAlertService
    {
        private readonly HttpClient _httpClient;

        public AlertService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ResponseAPI<Dictionary<string, object>>> SendAlert(AlertRate alertRate) 
      {

        try {
            // Configuration pour convertir en camelCase
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // Sérialisation en camelCase
            string jsonAlert = JsonSerializer.Serialize(alertRate, options);
            Console.WriteLine($"Valeur de json est {jsonAlert}");

            var content = new StringContent(jsonAlert, Encoding.UTF8, "application/json");          
            HttpResponseMessage response = await _httpClient.PostAsync(Constant.ApiBaseUrl + "/updt-alert", content);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Réponse de await est : {jsonResponse}");

                // Désérialisation avec camelCase
                return JsonSerializer.Deserialize<ResponseAPI<Dictionary<string, object>>>(jsonResponse, options);
            }
            else
            {
                throw new Exception($"Erreur API : {response.StatusCode}");
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"Erreur lors de la connexion : {ex.Message}");
            throw;
        }
    }


    }
}
