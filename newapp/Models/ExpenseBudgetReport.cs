using System ;

namespace newapp.Models 
{
        
    public class ExpenseBudgetReport
    {

        public double SommeBudgets { get; set; }
        public double SommeTickets { get; set; }
        public double SommeLeads { get; set; }
    
        public string SommeBudgetsStr() {
            return SommeBudgets.ToString().Replace(",", ".");
        }

        public string SommeTicketsStr() {
            return SommeTickets.ToString().Replace(",", ".");
        }
        
        public string SommeLeadsStr() {
            return SommeLeads.ToString().Replace(",", ".");
        }
    }

}
