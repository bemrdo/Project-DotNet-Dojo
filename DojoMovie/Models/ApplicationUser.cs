using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace DojoMovie.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public byte[]? ProfilePicture { get; set; }

    }
}
