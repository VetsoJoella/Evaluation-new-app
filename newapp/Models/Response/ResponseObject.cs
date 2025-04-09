using System;
using System.Collections.Generic;

namespace newapp.Models.Response
{
    public class ResponseObject
    {
        public Dictionary<string, object> Map { get; set; }

        // Constructeur sans paramètre (équivalent de @NoArgsConstructor)
        public ResponseObject()
        {
            Map = new Dictionary<string, object>();
        }

        // Constructeur avec paramètres (équivalent de @AllArgsConstructor)
        public ResponseObject(Dictionary<string, object> map)
        {
            Map = map ?? new Dictionary<string, object>();
        }

        // Méthode pour ajouter une clé/valeur (équivalent de add(String, Object) en Java)
        public void Add(string key, object value)
        {
            Map[key] = value;
        }

        public T GetValue<T>(string key, T defaultValue = default)
        {
            if (Map.TryGetValue(key, out object value) && value is T typedValue)
            {
                return typedValue;
            }
            return defaultValue;
        }

        // public T GetValue<T>(string key, T defaultValue = default)
        // {
        //     if (Map.TryGetValue(key, out object value) && value is T typedValue)
        //     {
        //         return typedValue;
        //     }
        //     return defaultValue;
        // }
    }
}
