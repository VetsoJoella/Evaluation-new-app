
using newapp.Models.Response;
using newapp.Models;

namespace newapp.Services.Alert
{
    public interface IAlertService 
    {
        Task<ResponseAPI<Dictionary<string, object>>> SendAlert(AlertRate alertRate) ;
    }
}