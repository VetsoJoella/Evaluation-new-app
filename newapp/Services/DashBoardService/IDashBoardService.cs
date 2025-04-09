using newapp.Models.Response;
using newapp.Models;

namespace newapp.Services.DashBoardService
{
    public interface IDashBoardService 
    {
        Task<ResponseAPI<DashBoard>> GetDashBoard() ;

        // Task<ResponseAPI<CustomerContribution>> GetCustomerContribution(Intervalle intervalle) ;
        Task<ResponseAPI<List<CustomerContributionItem>>> GetCustomerContribution(Intervalle intervalle) ;
        
        Task<ResponseAPI<ExpenseBudgetReport>> GetBudgetReport(Intervalle intervalle) ;

        Task<ResponseAPI<List<MinLeadTicket>>> GetTickets(Intervalle intervalle) ;
        Task<ResponseAPI<List<MinLeadTicket>>> GetLeads(Intervalle intervalle) ;

    }
}