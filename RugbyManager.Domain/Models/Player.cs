using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManager.Domain.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        [MaxLength(150)]
        public string DOB { get; set; } = string.Empty;
    }
}
