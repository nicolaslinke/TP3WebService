using System.ComponentModel.DataAnnotations;

namespace flappyBird_Server.Models
{
    public class LoginDTO
    {
        [Required]
        public String Username { get; set; } = null!;

        [Required]
        public String Password { get; set; } = null!;
    }
}
