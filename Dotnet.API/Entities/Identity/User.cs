using Microsoft.AspNetCore.Identity;

namespace api.Entities
{
    public class User : IdentityUser<long>
    {
        public required string MobileNumber { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public ICollection<Address>? Addresses { get; set; }
    }
}