using Microsoft.AspNetCore.Identity;

namespace AspNetProjekt.Models
{
    public class MyUser : IdentityUser
    {
        public Customer? customer { get; set; }
    }
}
