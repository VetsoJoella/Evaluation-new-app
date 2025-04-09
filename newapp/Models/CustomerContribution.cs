using System ; 
using System.Text.Json;
using newapp.Models ;

namespace newapp.Models 
{
   public class CustomerContribution
    {
        // Utilisez un dictionnaire public pour la désérialisation
   public List<CustomerContributionItem> Items { get; set; } = new List<CustomerContributionItem>();
        // Vous pouvez garder vos méthodes utilitaires si nécessaire
      public string GetKeysAndTicketsAsString()
        {
            if (Items == null || !Items.Any())
                return "[]";

            // Format: ["John Doe: 1", "Jane Smith: 2"]
            return "[" + string.Join(", ", 
                Items.Select(item => $"\"{item.Customer}: {item.TicketsContributions}\"")) + "]";
        }

        public string GetKeysAndLeadsAsString()
        {
            if (Items == null || !Items.Any())
                return "[]";

            // Format: ["John Doe: 3", "Jane Smith: 0"] 
            return "[" + string.Join(", ", 
                Items.Select(item => $"\"{item.Customer}: {item.LeadsContributions}\"")) + "]";
        }

        // public string GetKeysAsString()
        // {
        //     if (Items == null || !Items.Any())
        //         return "[]";

        //     // Format: ["John Doe", "Jane Smith"]
        //     return "[" + string.Join(", ", Items.Select(item => $"\"{item.Customer}\"")) + "]";
        // }

        // public string GetKeysAsString()
        // {
        //     if (Items == null || !Items.Any())
        //         return "[]";

        //     // Format: ['John Doe', 'Jane Smith']
        //     return "[" + string.Join(", ", Items.Select(item => $"'{item.Customer}'")) + "]";
        // }
       public string GetKeysAsJsonArray()
        {
            if (Items == null || !Items.Any())
                return "[]";

            // Sérialisation manuelle en JSON
            var names = Items.Select(item => item.Customer);
            return JsonSerializer.Serialize(names);
        }
        public string GetTicketsValuesAsString()
        {
            if (Items == null || !Items.Any())
                return "[]";

            // Format: [1, 0, 3] (valeurs brutes pour datasets)
            return "[" + string.Join(", ", Items.Select(item => item.TicketsContributions)) + "]";
        }

        public string GetLeadsValuesAsString()
        {
            if (Items == null || !Items.Any())
                return "[]";

            // Format: [3, 2, 0] (valeurs brutes pour datasets)
            return "[" + string.Join(", ", Items.Select(item => item.LeadsContributions)) + "]";
        }

        // public string GetKeysAsString()
        // {
        //     // Vérifie si le dictionnaire est null ou vide
        //     if (Contributions == null || Contributions.Count == 0)
        //     {
        //         return string.Empty;
        //     }

        //     // Utilise string.Join pour concaténer les clés avec des virgules
        //     return string.Join(", ", Contributions.Keys);
        // }
    }
     
}