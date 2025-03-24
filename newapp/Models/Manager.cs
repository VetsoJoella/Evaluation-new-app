using System.ComponentModel.DataAnnotations;
using newapp.Exceptions;

namespace newapp.Models
{
    public class Manager
    {
        // Rendre le champ Name requis avec un message d'erreur personnalisé
        [Required(ErrorMessage = "Name is requires.")]
        public string Name { get; set; }

        // Rendre le champ Password requis avec un message d'erreur personnalisé
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }


        public void Connection()
        {
            // Simuler un cas d'erreur
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
            {
                throw new ConnectionManagerException("Le nom d'utilisateur et le mot de passe sont requis.", this);
            }

            if (Name != "admin" || Password != "1234") // Simuler une validation de connexion
            {
                throw new ConnectionManagerException("Nom d'utilisateur ou mot de passe incorrect.", this);
            }

            Console.WriteLine($"Connexion réussie pour {Name}.");
        }
    }
}
