using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Domain.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; } 
        [Required]
        public int Age { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
