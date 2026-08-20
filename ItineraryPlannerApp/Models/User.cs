using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } =  string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;

        public User() { }
        public User(string name, string email, string passwordHash)
        {
            DisplayName = name;
            Email = email;
            PasswordHash = passwordHash;
            Role = UserRole.User;
        }
    }
}
