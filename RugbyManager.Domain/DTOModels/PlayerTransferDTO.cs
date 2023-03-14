using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManager.Domain.DTOModels
{
    public class PlayerTransferDTO
    {
        public int TeamFromId { get; set; }
        public int TeamToId { get; set; } 
        public int PlayerId { get; set; }
    }
}
