using Microsoft.EntityFrameworkCore;
using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;
using RugbyManager.Persistence;
using RugbyManager.Services.Players;

namespace RugbyManager.Services.Teams
{
    public class TeamsService : ITeamsService
    {
        private readonly RugbyManagerContext _rugbyManagerContext;
        private readonly IPlayersService playersService;
        public TeamsService(RugbyManagerContext rugbyManagerContext, IPlayersService playersService)
        {
            this._rugbyManagerContext = rugbyManagerContext;
            this.playersService=playersService;
        }
        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await _rugbyManagerContext.Teams.ToListAsync();

        }
        public async Task<Team> GetTeam(int id)
        {
            return await _rugbyManagerContext.Teams.FindAsync(id);
        }
        public async Task<MessageDTO> CreateTeam(TeamDTO team)
        {
            Team _team = new Team();
            _team.Name = team.Name;
            _team.Description = team.Description;
            _rugbyManagerContext.Add(_team);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Team with id: {_team.TeamId} has been created succesfully" };
        }
        public async Task<MessageDTO> UpdateTeam(int id, TeamDTO team)
        {
            Team _team = await _rugbyManagerContext.Teams.FindAsync(id);
            if (_team == null)
            {
                throw new Exception($"Team with id: {id} not found");
            }
            _team.Name = team.Name;
            _team.Description = team.Description;

            _rugbyManagerContext.Update(_team);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Team with id: {id} updated successfully" };
        }

        public async Task<MessageDTO> DeleteTeam(int id)
        {
            Team _team = await _rugbyManagerContext.Teams.FindAsync(id);
            if (_team == null)
            {
                throw new Exception($"Team with id: {id} not found");
            }
            _rugbyManagerContext.Remove(_team);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Team with id: {id} deleted successfully" };
        }

        public async Task<MessageDTO> AddPlayerToTeam(int teamId, int playerId)
        {
            Team _team = await _rugbyManagerContext.Teams.FindAsync(teamId);
            if (_team == null)
            {
                throw new Exception($"Team with id: {teamId} not found");
            }

            Player player = _team.Players.FirstOrDefault(x => x.PlayerId == playerId);
            if (player != null)
            {
                return new MessageDTO { Message = $"Player {player.FirstName} {player.LastName} already exists in the {_team.Name} team" };
            }

            player = await this.playersService.GetPlayer(playerId);
            if (player == null)
            {
                throw new Exception($"Player with id: {playerId} not found");
            }
            _team.Players.Add(player);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Player {player.FirstName} {player.LastName} has been added to the {_team.Name} team successfully" };
        }

        public async Task<MessageDTO> RemovePlayerFromTeam(int teamId, int playerId)
        {
            Team _team = await _rugbyManagerContext.Teams.FindAsync(teamId);
            if (_team == null)
            {
                throw new Exception($"Team with id: {teamId} not found");
            }

            Player player = _team.Players.FirstOrDefault(x => x.PlayerId == playerId);
            if (player == null)
            {
                throw new Exception($"Player with id: {playerId} not found in team {_team.Name}");
            }
            _team.Players.Remove(player);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Player {player.FirstName} {player.LastName} has been removed from {_team.Name} team successfully" };
        }

        public async Task<MessageDTO> TransferPlayerBetweenTeams(int teamFromId, int teamToId, int playerId)
        {
            Team _teamFrom = await _rugbyManagerContext.Teams.FindAsync(teamFromId);
            if (_teamFrom == null)
            {
                throw new Exception($"Team with id: {teamFromId} not found");
            }

            Team _teamTo = await _rugbyManagerContext.Teams.FindAsync(teamToId);
            if (_teamTo == null)
            {
                throw new Exception($"Team with id: {teamToId} not found");
            }

            Player player0 = _teamFrom.Players.FirstOrDefault(x => x.PlayerId == playerId);
            if (player0 == null)
            {
                throw new Exception($"Player with id: {playerId} not found in team {_teamFrom.Name}");
            }

            Player player1 = _teamTo.Players.FirstOrDefault(x => x.PlayerId == playerId);
            if (player1 != null)
            {
                _teamFrom.Players.Remove(player0);
                await _rugbyManagerContext.SaveChangesAsync();
                return new MessageDTO { Message = $"Player {player0.FirstName} {player0.LastName} has been transferred from {_teamFrom.Name} to {_teamTo.Name} team successfully" };
            }
            _teamFrom.Players.Remove(player0);
            _teamTo.Players.Add(player0);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Player {player0.FirstName} {player0.LastName} has been transferred from {_teamFrom.Name} to {_teamTo.Name} team successfully" };
        }

        public async Task<MessageDTO> SwapPlayersBetweenTeams(int playerAId, int playerAteamId, int playerBId, int playerBteamId)
        {
            Team playerAteam = await _rugbyManagerContext.Teams.FindAsync(playerAteamId);
            if (playerAteam == null)
            {
                throw new Exception($"Team with id: {playerAteamId} not found");
            }

            Player playerA = playerAteam.Players.FirstOrDefault(x => x.PlayerId == playerAId);
            if (playerA == null)
            {
                throw new Exception($"Player with id: {playerAId} not found in team {playerAteam.Name}");
            }

            Team playerBteam = await _rugbyManagerContext.Teams.FindAsync(playerBteamId);
            if (playerBteam == null)
            {
                throw new Exception($"Team with id: {playerBteamId} not found");
            }

            Player playerB = playerBteam.Players.FirstOrDefault(x => x.PlayerId == playerBId);
            if (playerB == null)
            {
                throw new Exception($"Player with id: {playerBId} not found in team {playerBteam.Name}");
            }
            playerAteam.Players.Remove(playerA);
            playerBteam.Players.Remove(playerB);
            playerAteam.Players.Add(playerB);
            playerBteam.Players.Add(playerA);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Player {playerA.FirstName} {playerA.LastName} has been transfered to {playerBteam.Name}, while player {playerB.FirstName} {playerB.LastName} has been transfered to {playerAteam.Name}" };
        }
    }
}
