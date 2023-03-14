using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;

namespace RugbyManager.Services.Stadiums
{
    public interface IStadiumsService
    {
        Task<MessageDTO> AddTeamToStadium(int stadiumId, int teamId);
        Task<MessageDTO> CreateStadium(StadiumDTO stadium);
        Task<MessageDTO> DeleteStadium(int id);
        Task<Stadium> GetStadium(int id);
        Task<IEnumerable<Stadium>> GetAllStadiums();
        Task<MessageDTO> RemoveTeamFromStadium(int stadiumId, int teamId);
        Task<MessageDTO> UpdateStadium(int id, StadiumDTO stadium);
    }
}