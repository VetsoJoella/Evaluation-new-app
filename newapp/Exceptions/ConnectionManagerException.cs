using System;
using newapp.Models; // Assurez-vous que le namespace correspond à celui de votre classe Manager

namespace newapp.Exceptions
{
    public class ConnectionManagerException : Exception
    {
        public Manager ManagerInfo { get; }

        // Constructeur par défaut
        public ConnectionManagerException()
        {
        }

        // Constructeur avec un message
        public ConnectionManagerException(string message)
            : base(message)
        {
        }

        // Constructeur avec un message et un objet Manager
        public ConnectionManagerException(string message, Manager manager)
            : base(message)
        {
            ManagerInfo = manager;
        }

        // Constructeur avec un message, une exception interne et un objet Manager
        public ConnectionManagerException(string message, Exception innerException, Manager manager)
            : base(message, innerException)
        {
            ManagerInfo = manager;
        }

        // Redéfinition de ToString pour inclure les infos du Manager
        public override string ToString()
        {
            return $"{base.ToString()} | Manager: {ManagerInfo?.Name ?? "Unknown"}";
        }
    }
}
