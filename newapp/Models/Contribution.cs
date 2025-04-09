
using System ; 


namespace newapp.Models {

    public class Contribution
    {
        public int TicketsContributions { get; set; }
        public int LeadsContributions { get; set; }

        public Contribution() { } // Constructeur sans paramètre pour la désérialisation

        public Contribution(int tickets, int leads)
        {
            TicketsContributions = tickets;
            LeadsContributions = leads;
        }
    }
}

