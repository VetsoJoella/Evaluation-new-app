using System ; 

using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace newapp.Models
{
    
    public class CustomerContributionItem
    {
        [JsonPropertyName("customer")]
        public string Customer { get; set; }

        [JsonPropertyName("ticketsContributions")]
        public int TicketsContributions { get; set; }

        [JsonPropertyName("leadsContributions")]
        public int LeadsContributions { get; set; }
    }
}