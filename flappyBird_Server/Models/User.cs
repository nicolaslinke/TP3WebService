using Microsoft.AspNetCore.Identity;

namespace flappyBird_Server.Models
{
    public class User : IdentityUser
    {
        public List<Score> Scores { get; set; } = null!;
    }
}
