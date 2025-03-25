using Microsoft.AspNetCore.Http; // Nécessaire pour HttpContext
using System;

namespace newapp.Services
{
    public class CheckLogin
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Injection de dépendance pour HttpContext
        public CheckLogin(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated()
        {
            // Accès au HttpContext via l'accessor
            int? userId = _httpContextAccessor.HttpContext?.Session.GetInt32("UserId");
            return userId.HasValue;
        }
    }
}