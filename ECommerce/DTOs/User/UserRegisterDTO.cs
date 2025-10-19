﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public string? PhoneNumber { get; set; }

        public string Role { get; set; } ="Admin";
    }
}
