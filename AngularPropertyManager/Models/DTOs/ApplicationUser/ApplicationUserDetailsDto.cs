using System;

namespace AngularPropertyManager.Models.DTOs.ApplicationUser
{
    public class ApplicationUserDetailsDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
