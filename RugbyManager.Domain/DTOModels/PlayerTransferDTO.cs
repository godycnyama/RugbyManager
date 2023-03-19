namespace RugbyManager.Domain.DTOModels
{
    public class PlayerTransferDTO
    {
        public int TeamFromId { get; set; }
        public int TeamToId { get; set; } 
        public int PlayerId { get; set; }
    }
}
