


using Microsoft.AspNetCore.Identity;

namespace ApwPayroll_Domain.Entities.AspUsers
{
    public class AspUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }

    }
}
