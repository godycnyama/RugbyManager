using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Domain.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
