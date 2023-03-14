using Microsoft.EntityFrameworkCore;
using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;
using RugbyManager.Persistence;

namespace RugbyManager.Services.Players
{
    public class PlayersService : IPlayersService 
    {
        private readonly RugbyManagerContext _rugbyManagerContext;
        public PlayersService(RugbyManagerContext rugbyManagerContext)
        {
            _rugbyManagerContext = rugbyManagerContext;
        }
        public async Task<IEnumerable<Player>>  GetAllPlayers()
        {
            return await _rugbyManagerContext.Players.ToListAsync();

        }
        public async Task<Player> GetPlayer(int id)
        {
            return await _rugbyManagerContext.Players.FindAsync(id);

        }
        public async Task<MessageDTO> CreatePlayer(PlayerDTO player)
        {
            Player _player = new Player();
            _player.FirstName = player.FirstName;
            _player.LastName = player.LastName;
            _player.Age = player.Age;
            _player.Weight = player.Weight;
            _player.Height = player.Height;
            _player.DateOfBirth = player.DateOfBirth;

            _rugbyManagerContext.Add(_player);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Player with id: {_player.PlayerId} has been created succesfully" };
        }
        public async Task<MessageDTO> UpdatePlayer(int id, PlayerDTO player)
        {
            Player _player = await _rugbyManagerContext.Players.FindAsync(id);
            if (_player == null)
            {
                throw new Exception($"Player with id: {id} not found");
            }
            _player.FirstName = player.FirstName;
            _player.LastName = player.LastName;
            _player.Age = player.Age;
            _player.Weight = player.Weight;
            _player.Height = player.Height;
            _player.DateOfBirth = player.DateOfBirth;

            _rugbyManagerContext.Update(_player);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Player with id: {id} updated successfully" };
        }

        public async Task<MessageDTO> DeletePlayer(int id)
        {
            Player _player = await _rugbyManagerContext.Players.FindAsync(id);
            if (_player == null)
            {
                throw new Exception($"Player with id: {id} not found");
            }
            _rugbyManagerContext.Remove(_player);
            await _rugbyManagerContext.SaveChangesAsync();
            return new MessageDTO { Message = $"Player with id: {id} deleted successfully" };
        }
    }
}
