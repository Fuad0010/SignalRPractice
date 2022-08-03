using Microsoft.AspNetCore.Identity;

namespace SignalRPractise.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
        public string ConnectId { get; set; }
    }
}
