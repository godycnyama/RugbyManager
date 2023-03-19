using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Domain.Models
{
    public class Stadium
    {
        [Key]
        public int StadiumId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } 
        [Required]
        [MaxLength(150)]
        public string Location { get; set; } 
        [Required]
        public int Capacity { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
