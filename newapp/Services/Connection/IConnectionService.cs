using newapp.Models;
using System.Threading.Tasks;
using newapp.Models.Manager;

namespace newapp.Services.Connection
{
    public interface IConnectionService
    {
        Task<Manager> Connection(Manager manager); 
    }
}