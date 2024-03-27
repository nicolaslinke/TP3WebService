using Microsoft.AspNetCore.Identity;

namespace flappyBird_Server.Models
{
    public class User : IdentityUser
    {
        public virtual List<Score> Scores { get; set; } = null!;
    }
}
