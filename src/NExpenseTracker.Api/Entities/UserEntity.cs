using Microsoft.AspNetCore.Identity;

namespace NExpenseTracker.Api.Entities
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; }

    }
}
