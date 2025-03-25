using System ; 

namespace newapp.Models
{
    
    public class Lead
    {
        // Propriété Id (identifiant unique pour chaque lead)
        public int Id { get; set; }

        // Propriété Name (nom du lead)
        public string Name { get; set; }

        // Propriété Status (statut du lead, par exemple "nouveau", "en cours", etc.)
        public string Status { get; set; }

        // Propriété Customer (le client associé au lead)
        public Customer Customer { get; set; }

        // Propriété User (utilisateur qui gère ce lead)
        public User User { get; set; }

        // Propriété Created (date de création du lead)
        public DateTime Created { get; set; }

        // Propriété Amount (montant associé au lead, qui ne doit pas être <= 0)
        private decimal _amount;
        
        public decimal Amount
        {
            get { return _amount; }
            private set
            {
                // Validation pour s'assurer que Amount > 0
                if (value <= 0)
                {
                    throw new ArgumentException("Le montant doit être supérieur à zéro.");
                }
                _amount = value;
            }
        }

        // Méthode pour définir Amount avec validation
        public void SetAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Le montant doit être supérieur à zéro.");
            }
            _amount = amount;
        }
    }

}