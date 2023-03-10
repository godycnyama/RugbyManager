using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManager.Domain.Models
{
    public class Stadium
    {
        public int StadiumId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
