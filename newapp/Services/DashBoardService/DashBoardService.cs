using newapp.Models;
using newapp.Config  ; 
using newapp.Models.Response;
using newapp.Models;

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace newapp.Services.DashBoardService
{
    public class DashBoardService : IDashBoardService
    {
        private readonly HttpClient _httpClient;


        public DashBoardService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ResponseAPI<DashBoard>> GetDashBoard()
        {
           try
            {                
                HttpResponseMessage response = await _httpClient.GetAsync(Constant.ApiBaseUrl+"/dashboard");

        //         // Vérifier la réponse
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions{
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    Console.WriteLine($"Réponse de await est : {jsonResponse} ");
                    return JsonSerializer.Deserialize<ResponseAPI<DashBoard>>(jsonResponse, options);
                }
                else
                {
                    throw new Exception($"Erreur API : {response.StatusCode}");
                }
                return null ; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la connexion : {ex.Message}");
                throw ex ;
            }
        }
    }
}
