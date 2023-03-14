using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;

namespace RugbyManager.Services.Teams
{
    public interface ITeamsService
    {
        Task<MessageDTO> AddPlayerToTeam(int teamId, int playerId);
        Task<MessageDTO> CreateTeam(TeamDTO team);
        Task<MessageDTO> DeleteTeam(int id);
        Task<IEnumerable<Team>> GetAllTeams();
        Task<Team> GetTeam(int id);
        Task<MessageDTO> RemovePlayerFromTeam(int teamId, int playerId);
        Task<MessageDTO> SwapPlayersBetweenTeams(int playerAId, int playerAteamId, int playerBId, int playerBteamId);
        Task<MessageDTO> TransferPlayerBetweenTeams(int teamFromId, int teamToId, int playerId);
        Task<MessageDTO> UpdateTeam(int id, TeamDTO team);
    }
}