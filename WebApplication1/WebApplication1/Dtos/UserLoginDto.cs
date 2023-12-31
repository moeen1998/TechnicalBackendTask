﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class UserLoginDto
    {
        
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(8)]
        public string Password { get; set; }
    }
}
