using newapp.Models.Response ;
using newapp.Config ; 
using newapp.Models;

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace newapp.Services.ImportSrv
{
    
    public class ImportService : IImportService
    {
         private readonly HttpClient _httpClient;

        public ImportService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ResponseAPI<string>> SendImportData(string data)
        {
           try
            {
                // Convertir l'objet User en JSON
                // string jsonUser = JsonSerializer.Serialize(data);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                // Console.WriteLine($"content: {jsonUser}");
                HttpResponseMessage response = await _httpClient.PostAsync(Constant.ApiBaseUrl+"/import", content);


                // Vérifier la réponse
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions{
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    // Console.WriteLine($"Réponse de await est : {jsonResponse} ");
                    return JsonSerializer.Deserialize<ResponseAPI<string>>(jsonResponse, options);
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