using Microsoft.EntityFrameworkCore;
using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;
using RugbyManager.Persistence;
using RugbyManager.Services.Teams;

namespace RugbyManager.Services.Stadiums
{
    public class StadiumsService : IStadiumsService
    {
        private readonly RugbyManagerContext _rugbyManagerContext;
        private readonly ITeamsService _teamsService;
        public StadiumsService(RugbyManagerContext rugbyManagerContext, ITeamsService teamsService)
        {
            _rugbyManagerContext = rugbyManagerContext;
            _teamsService = teamsService;
        }
        public async Task<IEnumerable<Stadium>> GetAllStadiums()
        {
            return await _rugbyManagerContext.Stadiums.ToListAsync();

        }
        public async Task<Stadium> GetStadium(int id)
        {
            return await _rugbyManagerContext.Stadiums.FindAsync(id);

        }
        public async Task<MessageDTO> CreateStadium(StadiumDTO stadium)
        {
            Stadium _stadium = new Stadium();
            _stadium.Name = stadium.Name;
            _stadium.Location = stadium.Location;
            _stadium.Capacity = stadium.Capacity;
            _rugbyManagerContext.Add(_stadium);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Stadium with id: {_stadium.StadiumId} has been created succesfully" };
        }
        public async Task<MessageDTO> UpdateStadium(int id, StadiumDTO stadium)
        {
            Stadium _stadium = await _rugbyManagerContext.Stadiums.FindAsync(id);
            if (_stadium == null)
            {
                throw new Exception($"Stadium with id: {id} not found");
            }
            _stadium.Name = stadium.Name;
            _stadium.Location = stadium.Location;
            _stadium.Capacity = stadium.Capacity;

            _rugbyManagerContext.Update(_stadium);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Stadium with id: {id} updated successfully" };
        }

        public async Task<MessageDTO> DeleteStadium(int id)
        {
            Stadium _stadium = await _rugbyManagerContext.Stadiums.FindAsync(id);
            if (_stadium == null)
            {
                throw new Exception($"Stadium with id: {id} not found");
            }
            _rugbyManagerContext.Remove(_stadium);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Stadium with id: {id} deleted successfully" };
        }

        public async Task<MessageDTO> AddTeamToStadium(int stadiumId, int teamId)
        {
            Stadium _stadium = await _rugbyManagerContext.Stadiums.FindAsync(stadiumId);
            if (_stadium == null)
            {
                throw new Exception($"Stadium with id: {stadiumId} not found");
            }

            Team team = _stadium.Teams.FirstOrDefault(x => x.TeamId == teamId);
            if (team != null)
            {
                return new MessageDTO { Message = $"Team {team.Name} already assigned to the {_stadium.Name} stadium" };
            }

            team = await this._teamsService.GetTeam(teamId);
            if (team == null)
            {
                throw new Exception($"Team with id: {teamId} not found");
            }
            _stadium.Teams.Add(team);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Team {team.Name} has been assigned to the {_stadium.Name} stadium" };
        }

        public async Task<MessageDTO> RemoveTeamFromStadium(int stadiumId, int teamId)
        {
            Stadium _stadium = await _rugbyManagerContext.Stadiums.FindAsync(stadiumId);
            if (_stadium == null)
            {
                throw new Exception($"Stadium with id: {stadiumId} not found");
            }

            Team team = _stadium.Teams.FirstOrDefault(x => x.TeamId == teamId);
            if (team == null)
            {
                throw new Exception($"Team with id: {teamId} not found in {_stadium.Name} stadium");
            }
            _stadium.Teams.Remove(team);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Team {team.Name} has been removed from {_stadium.Name} stadium successfully" };
        }
    }
}
