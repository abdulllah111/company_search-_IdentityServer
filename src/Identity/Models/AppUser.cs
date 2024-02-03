using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
   public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; internal set; }
    }
}