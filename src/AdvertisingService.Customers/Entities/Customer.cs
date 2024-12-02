using Microsoft.AspNetCore.Identity;

namespace AdvertisingService.Customers.Entities
{
    public class Customer : IdentityUser
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public int? Age { get; set; }
        public string Bio { get; set; } = string.Empty;
    }
}
