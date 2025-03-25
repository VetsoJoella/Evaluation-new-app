using newapp.Models.Response;
using newapp.Models;

namespace newapp.Services.DashBoardService
{
    public interface IDashBoardService 
    {
        Task<ResponseAPI<DashBoard>> GetDashBoard() ;
    }
}