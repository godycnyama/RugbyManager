using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RugbyManager.Domain.Models;
using RugbyManager.Persistence;
using RugbyManager.Services.Players;

namespace RugbyManager.API.PlayersAPI
{
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayersService _playersService;

        public PlayersController(IPlayersService playersService)
        {
            _playersService = playersService;
        }

        [HttpGet]
        [Route("api/players/get-all-players")]
        public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers()
        {
            try
            {
                var players = await _playersService.GetAllPlayers();

                if (players == null)
                {
                    return NotFound("No player records found");
                }
                return Ok(players);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/players/get-player/{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            try
            {
                var player = await _playersService.GetPlayer(id);

                if (player == null)
                {
                    return NotFound("Player not found");
                }
                return Ok(player);  
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/players/update-player/{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] PlayerDTO playerDto)
        {
            try
            {
                var message = await _playersService.UpdatePlayer(id,playerDto);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/players/create-player")]
        public async Task<ActionResult<Player>> CreatePlayer([FromBody] PlayerDTO playerDto)
        {
            try
            {
                var message = await _playersService.CreatePlayer(playerDto);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/players/delete-player/{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            try
            {
                var message = await _playersService.DeletePlayer(id);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
