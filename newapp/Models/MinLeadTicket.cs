using System ;
// using newapp.Utils ; 
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace newapp.Models
{
    public class MinLeadTicket
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Customer { get; set; }
        public double Amount { get; set; }
        public string Created_at { get; set; }

        // Constructeur par défaut
        public MinLeadTicket() { }

        // Constructeur avec paramètres
        public MinLeadTicket(int id, string subject, string customer, double amount)
        {
            Id = id;
            Subject = subject;
            Customer = customer;
            Amount = amount;
        }
    }
}