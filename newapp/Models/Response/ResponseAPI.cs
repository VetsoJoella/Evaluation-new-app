using System.Text.Json.Serialization;

using newapp.Models.Response ;

namespace newapp.Models.Response 
{
    public class ResponseAPI
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public ResponseObject Data { get; set; }

        // Constructeur sans paramètre (équivalent de @NoArgsConstructor)
        public ResponseAPI() { }

        // Constructeur avec paramètres (équivalent de @AllArgsConstructor)
        public ResponseAPI(int status, string message, string error, ResponseObject data)
        {
            Status = status;
            Message = message;
            Error = error;
            Data = data;
        }
    }
}
