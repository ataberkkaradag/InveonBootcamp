using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Models
{
    public class AppUser:IdentityUser<Guid>
    {
        public string? City { get; set; }
    }
}
