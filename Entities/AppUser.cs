using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirtsName { get; set; }
        public string LastName { get; set; }
    }
}
