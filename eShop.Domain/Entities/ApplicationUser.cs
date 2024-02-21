using Microsoft.AspNetCore.Identity;

namespace eShop.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public IList<RefreshToken>? RefreshTokens { get; set; }
        public bool IsDeleted { get; set; }

        public ApplicationUser()
        {
            RefreshTokens = new List<RefreshToken>();
        }
    }
}
