using Microsoft.AspNetCore.Mvc;
using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;
using RugbyManager.Services.Stadiums;

namespace RugbyManager.API.StadiumsAPI
{
    [ApiController]
    public class StadiumsController : ControllerBase
    {
        private readonly IStadiumsService _stadiumsService;

        public StadiumsController(IStadiumsService stadiumsService)
        {
            _stadiumsService = stadiumsService;
        }

        [HttpGet]
        [Route("api/stadiums/get-all-stadiums")]
        public async Task<IActionResult> GetAllStadiums()
        {
            try
            {
                var stadiums = await _stadiumsService.GetAllStadiums();

                if (stadiums == null)
                {
                    return NotFound("No stadium records found");
                }
                return Ok(stadiums);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/stadiums/get-stadium/{id}")]
        public async Task<IActionResult> GetStadium(int id)
        {
            try
            {
                var stadium = await _stadiumsService.GetStadium(id);

                if (stadium == null)
                {
                    return NotFound("Stadium not found");
                }
                return Ok(stadium);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/stadiums/update-stadium/{id}")]
        public async Task<IActionResult> UpdateStadium(int id, [FromBody] StadiumDTO stadiumDto)
        {
            try
            {
                var message = await _stadiumsService.UpdateStadium(id, stadiumDto);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/stadiums/create-stadium")]
        public async Task<IActionResult> CreateStadium([FromBody] StadiumDTO stadiumDto)
        {
            try
            {
                var message = await _stadiumsService.CreateStadium(stadiumDto);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/stadiums/delete-stadium/{id}")]
        public async Task<IActionResult> DeleteStadium(int id)
        {
            try
            {
                var message = await _stadiumsService.DeleteStadium(id);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/stadiums/add-team-to-stadium")]
        public async Task<IActionResult> AddTeamToStadium([FromBody] StadiumTeamDTO stadiumTeamDTO)
        {
            try
            {
                var message = await _stadiumsService.AddTeamToStadium(stadiumTeamDTO.StadiumId, stadiumTeamDTO.TeamId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/stadiums/remove-team-from-stadium")]
        public async Task<IActionResult> RemoveTeamFromStadium([FromBody] StadiumTeamDTO stadiumTeamDTO)
        {
            try
            {
                var message = await _stadiumsService.RemoveTeamFromStadium(stadiumTeamDTO.StadiumId, stadiumTeamDTO.TeamId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
