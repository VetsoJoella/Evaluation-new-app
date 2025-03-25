using System ; 

namespace newapp.Models 
{
    public class User
    {
        // Propriété Id (unique pour chaque utilisateur)
        public int Id { get; set; }

        // Propriété Name (le nom de l'utilisateur)
        public string Name { get; set; }

        // Propriété Email (l'email de l'utilisateur)
        public string Email { get; set; }

    }

}
