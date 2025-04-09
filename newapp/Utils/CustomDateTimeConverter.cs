// using System ; 

// using System.Text.Json;
// using System.Threading.Tasks;
// using System.Text.Json.Serialization;

// namespace newapp.Utils
// {
//     public class CustomDateTimeConverter : JsonConverter<DateTime>
//     {
//         private readonly string[] _formats = {
//             "yyyy-MM-ddTHH:mm:ss.fffZ",
//             "yyyy-MM-ddTHH:mm:ssZ",
//             "dd/MM/yyyy HH:mm:ss",
//             "MM/dd/yyyy HH:mm:ss"
//         };

//         public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//         {
//             var dateString = reader.GetString();
//             foreach (var format in _formats)
//             {
//                 if (DateTime.TryParseExact(dateString, format, 
//                     CultureInfo.InvariantCulture,
//                     DateTimeStyles.AssumeUniversal, 
//                     out var date))
//                 {
//                     return date;
//                 }
//             }
//             throw new JsonException($"Could not parse {dateString} as DateTime.");
//         }
//     }
//         public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
//     {
//         writer.WriteStringValue(
//             value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture)
//         );
//     }
// }