using Microsoft.AspNetCore.Identity;

namespace api.Entities
{
    public class Role : IdentityRole<long>
    {
        public required string Title { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}