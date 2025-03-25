
using newapp.Models.Response;
using newapp.Models;

namespace newapp.Services.Connection
{
    public interface IConnectionService 
    {
        Task<ResponseAPI<User>> Connection(Manager manager) ;
    }
}