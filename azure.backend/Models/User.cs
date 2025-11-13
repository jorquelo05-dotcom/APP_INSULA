using System.ComponentModel.DataAnnotations;

namespace TerapiaApp.API.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string UserType { get; set; } = string.Empty; // "psychologist" or "patient"
        
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}