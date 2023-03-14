using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;

namespace RugbyManager.Services.Players
{
    public interface IPlayersService
    {
        Task<MessageDTO> CreatePlayer(PlayerDTO player);
        Task<MessageDTO> DeletePlayer(int id);
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<Player> GetPlayer(int id);
        Task<MessageDTO> UpdatePlayer(int id, PlayerDTO player);
    }
}