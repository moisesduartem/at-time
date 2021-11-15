using System.ComponentModel.DataAnnotations;

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
    }
}
