using newapp.Models;
using newapp.Config  ; 
using newapp.Models.Response;
using newapp.Models;

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

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
                // Console.WriteLine($"Erreur lors de la connexion : {ex.Message}");
                throw ex ;
            }
        }

        public async Task<ResponseAPI<ExpenseBudgetReport>> GetBudgetReport(Intervalle intervalle) {

            try
            {        
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                string jsonValue = JsonSerializer.Serialize(intervalle, options);
                // Console.WriteLine($"Valeur de json est {jsonValue}");

                var content = new StringContent(jsonValue, Encoding.UTF8, "application/json");          
                HttpResponseMessage response = await _httpClient.PostAsync(Constant.ApiBaseUrl + "/camembert", content);        

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Réponse de await est : {jsonResponse} ");
                    return JsonSerializer.Deserialize<ResponseAPI<ExpenseBudgetReport>>(jsonResponse, options);
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


        public async Task<ResponseAPI<List<CustomerContributionItem>>> GetCustomerContribution(Intervalle intervalle) {

            try
            {        
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                string jsonValue = JsonSerializer.Serialize(intervalle, options);
                // Console.WriteLine($"Valeur de json est {jsonValue}");

                var content = new StringContent(jsonValue, Encoding.UTF8, "application/json");          
                HttpResponseMessage response = await _httpClient.PostAsync(Constant.ApiBaseUrl + "/horizontal-chart", content);        

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    // Console.WriteLine($"Réponse de await est : {jsonResponse} ");
                    return JsonSerializer.Deserialize<ResponseAPI<List<CustomerContributionItem>>>(jsonResponse, options);
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

        public async Task<ResponseAPI<List<MinLeadTicket>>> GetLeads(Intervalle intervalle)
        {
           try
            {                
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                        NumberHandling = JsonNumberHandling.AllowReadingFromString

                };
                string jsonValue = JsonSerializer.Serialize(intervalle, options);
                var content = new StringContent(jsonValue, Encoding.UTF8, "application/json");   
                HttpResponseMessage response = await _httpClient.PostAsync(Constant.ApiBaseUrl + "/leads", content);        

        //         // Vérifier la réponse
                if (response.IsSuccessStatusCode) {

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    // Console.WriteLine($"Réponse de await LEAD est : {jsonResponse} ");
                    // var content = new StringContent(jsonValue, Encoding.UTF8, "application/json");          

                    return JsonSerializer.Deserialize<ResponseAPI<List<MinLeadTicket>>>(jsonResponse, options);
                }
                else {

                    throw new Exception($"Erreur API : {response.StatusCode}");
                }
                return null ; 
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"Erreur lors de la connexion : {ex.Message}");
                throw ex ;
            }
        }

        public async Task<ResponseAPI<List<MinLeadTicket>>> GetTickets(Intervalle intervalle)
        {
           try
            {        
                 var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString
                };
                string jsonValue = JsonSerializer.Serialize(intervalle, options); 
                var content = new StringContent(jsonValue, Encoding.UTF8, "application/json");          
                HttpResponseMessage response = await _httpClient.PostAsync(Constant.ApiBaseUrl + "/tickets", content);        
                Console.WriteLine($"Valeur JSON {jsonValue}");
        //         // Vérifier la réponse
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();                   
                    // Console.WriteLine($"Réponse de await TICKET est : {jsonResponse} ");
                    return JsonSerializer.Deserialize<ResponseAPI<List<MinLeadTicket>>>(jsonResponse, options);
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
