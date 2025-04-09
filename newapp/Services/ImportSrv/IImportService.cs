using System ;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

using newapp.Models.Response ;


namespace newapp.Services.ImportSrv
{
    public interface IImportService {


        Task<ResponseAPI<string>> SendImportData(string data);
    }
}