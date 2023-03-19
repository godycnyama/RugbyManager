using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RugbyManager.API.PlayersAPI;
using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;
using RugbyManager.Services.Players;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RugbyManager.Tests.ControllersUnitTests
{
    [TestClass]
    public class PlayersControllerUnitTests
    {
        private PlayersController _playersController;
        private Mock<IPlayersService>  _playersService;
        private PlayerDTO _createPlayerDTO = new PlayerDTO
        {
            Age = 23,
            DateOfBirth = new DateTime(),
            FirstName = "Charles",
            LastName = "Buckly",
            Height = 65,
        };

        private PlayerDTO _updatePlayerDTO = new PlayerDTO
        {
            Age = 23,
            DateOfBirth = new DateTime(),
            FirstName = "Charles",
            LastName = "Buckly",
            Height = 80
        };

        [TestInitialize]
        public void Initialize()
        {
            _playersService = new Mock<IPlayersService>();
            _playersController = new PlayersController(_playersService.Object);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyCreateNewPlayerReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Player created successfully"
            };
            _playersService.Setup(x => x.CreatePlayer(_createPlayerDTO)).Returns(Task.FromResult(messageDTO));
            var response
                = await _playersController.CreatePlayer(_createPlayerDTO) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _playersService.Verify(x => x.CreatePlayer(It.IsAny<PlayerDTO>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Player created successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyUpdatePlayerReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Player updated successfully"
            };
            _playersService.Setup(x => x.UpdatePlayer(It.IsAny<int>(), _updatePlayerDTO)).Returns(Task.FromResult(messageDTO));
            var response
                = await _playersController.UpdatePlayer(5, _updatePlayerDTO) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _playersService.Verify(x => x.UpdatePlayer(It.IsAny<int>(), It.IsAny<PlayerDTO>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Player updated successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyDeletePlayerReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Player deleted successfully"
            };
            _playersService.Setup(x => x.DeletePlayer(It.IsAny<int>())).Returns(Task.FromResult(messageDTO));
            var response
                = await _playersController.DeletePlayer(5) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _playersService.Verify(x => x.DeletePlayer(It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Player deleted successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyReturnAPlayerGivenID()
        {
            Player player = new Player
            {
                PlayerId = 5,
                Age = 23,
                FirstName = "Charles",
                LastName = "Buckly",
                Height = 80
            };
            
            _playersService.Setup(x => x.GetPlayer(It.IsAny<int>())).Returns(Task.FromResult(player));
            var response
                = await _playersController.GetPlayer(5) as ObjectResult;
            var actualResponse = (Player)response.Value;
            _playersService.Verify(x => x.GetPlayer(It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(5, actualResponse.PlayerId);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyReturnAllPlayers()
        {
            Player player = new Player
            {
                PlayerId = 5,
                Age = 23,
                FirstName = "Charles",
                LastName = "Buckly",
                Height = 80
            };

            _playersService.Setup(x => x.GetAllPlayers()).Returns(GetPlayers);
            var response
                = await _playersController.GetAllPlayers() as ObjectResult;
            var actualResponse = (List<Player>)response.Value;
            _playersService.Verify(x => x.GetAllPlayers(), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(3, actualResponse.Count);
        }

        private Task<IEnumerable<Player>>  GetPlayers()
        {
            IEnumerable<Player> _players =  new List<Player>()
            {
                new Player {
                    Age = 23,
                    FirstName = "Charles",
                    LastName = "Buckly",
                    Height = 80
                },
                new Player {
                    Age = 24,
                    DateOfBirth = new DateTime(),
                    FirstName = "James",
                    LastName = "Adam",
                    Height = 67
                },
                new Player {
                    Age = 21,
                    FirstName = "Cain",
                    LastName = "Host",
                    Height = 78
                },
            };
            return Task.FromResult(_players);
        }

        private Task<MessageDTO> GetPlayerCreatedMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Player created successfully"
            };
            return Task.FromResult(messageDTO);
        }

    }
}
