using System ; 

namespace newapp.Models
{
    public class Customer
    {
        // Propriété Id (unique pour chaque client)
        public int Id { get; set; }

        // Propriété Name (le nom du client)
        public string Name { get; set; }

        // Propriété Email (l'email du client)
        public string Email { get; set; }
    }

}