using Microsoft.AspNetCore.Mvc;
using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;
using RugbyManager.Services.Teams;

namespace RugbyManager.API.TeamsAPI
{
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;

        public TeamsController(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        [HttpGet]
        [Route("api/teams/get-all-teams")]
        public async Task<IActionResult> GetAllTeams()
        {
            try
            {
                var teams = await _teamsService.GetAllTeams();

                if (teams == null)
                {
                    return NotFound("No team records found");
                }
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/teams/get-team/{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            try
            {
                var team = await _teamsService.GetTeam(id);

                if (team == null)
                {
                    return NotFound("Team not found");
                }
                return Ok(team);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/teams/update-team/{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] TeamDTO teamDto)
        {
            try
            {
                var message = await _teamsService.UpdateTeam(id, teamDto);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/teams/create-team")]
        public async Task<IActionResult> CreateTeam([FromBody] TeamDTO teamDto)
        {
            try
            {
                var message = await _teamsService.CreateTeam(teamDto);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/teams/delete-team/{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            try
            {
                var message = await _teamsService.DeleteTeam(id);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/teams/add-player-to-team")]
        public async Task<IActionResult> AddPlayerToTeam([FromBody] TeamPlayerDTO teamPlayerDTO)
        {
            try
            {
                var message = await _teamsService.AddPlayerToTeam(teamPlayerDTO.TeamId, teamPlayerDTO.PlayerId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/teams/remove-player-from-team")]
        public async Task<IActionResult> RemovePlayerFromTeam([FromBody] TeamPlayerDTO teamPlayerDTO)
        {
            try
            {
                var message = await _teamsService.RemovePlayerFromTeam(teamPlayerDTO.TeamId, teamPlayerDTO.PlayerId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/teams/swap-players-between-teams")]
        public async Task<IActionResult> SwapPlayersBetweenTeams([FromBody] TeamsPlayersDTO teamsPlayersDTO)
        {
            try
            {
                var message = await _teamsService.SwapPlayersBetweenTeams(teamsPlayersDTO.PlayerAId, teamsPlayersDTO.PlayerAteamId, teamsPlayersDTO.PlayerBId, teamsPlayersDTO.PlayerBteamId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/teams/transfer-player-between-teams")]
        public async Task<IActionResult> TransferPlayerBetweenTeams([FromBody] PlayerTransferDTO playerTransferDTO)
        {
            try
            {
                var message = await _teamsService.TransferPlayerBetweenTeams(playerTransferDTO.TeamFromId, playerTransferDTO.TeamToId, playerTransferDTO.PlayerId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
