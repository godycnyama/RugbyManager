using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManager.Domain.DTOModels
{
    public class TeamsPlayersDTO
    {
        public int PlayerAId { get; set; } 
        public int PlayerAteamId { get; set; }
        public int PlayerBId { get; set; } 
        public int PlayerBteamId { get; set; }
    }
}
