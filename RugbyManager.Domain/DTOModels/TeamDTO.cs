using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Domain.Models
{
    public class TeamDTO
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
