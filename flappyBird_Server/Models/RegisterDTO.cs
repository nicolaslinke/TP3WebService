﻿using System.ComponentModel.DataAnnotations;

namespace flappyBird_Server.Models
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress] 
        public string Email { get; set;} = null!;

        [Required]
        public string Password { get; set;} = null!;

        [Required]
        public string PasswordConfirm { get; set;} = null!;
    }
}
