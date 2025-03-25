using System;

using System.ComponentModel.DataAnnotations;


namespace newapp.Models
{
    public class AlertRate
    {
        private DateOnly _startDate;
        private DateOnly _endDate;
        private decimal _percentage;

        // Propriétés avec validation
        public DateOnly StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
            }
        }

        public DateOnly EndDate
        {
            get => _endDate;
            set
            {
                if (value <= StartDate)
                {
                    throw new ArgumentException("La date de fin doit être postérieure à la date de début");
                }
                _endDate = value;
            }
        }

        public decimal Percentage
        {
            get => _percentage;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Le pourcentage doit être supérieur à 0");
                }
                _percentage = value;
            }
        }

        // Constructeur
        public AlertRate(DateOnly startDate, DateOnly endDate, decimal percentage)
        {
            // On assigne d'abord les dates (la validation se fera dans les setters)
            _startDate = startDate;
            _endDate = endDate;
            
            // Validation des dates
            if (_startDate >= _endDate)
            {
                throw new ArgumentException("La date de début doit être antérieure à la date de fin");
            }

            // Validation du pourcentage
            Percentage = percentage;
        }

        public AlertRate(){

        }
    }

}
