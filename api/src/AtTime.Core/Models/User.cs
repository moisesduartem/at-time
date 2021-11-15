using AtTime.Core.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtTime.Core.Models
{
    public sealed class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }
        
        public string RoleName { get => Enum.GetName(Role); }

        public IEnumerable<Point> Points { get; set; }
    }
}
