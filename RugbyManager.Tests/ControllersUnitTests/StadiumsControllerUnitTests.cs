using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RugbyManager.API.StadiumsAPI;
using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;
using RugbyManager.Services.Stadiums;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RugbyManager.Tests.ControllersUnitTests
{
    [TestClass]
    public class StadiumsControllerUnitTests
    {
        private StadiumsController _stadiumsController;
        private Mock<IStadiumsService>  _stadiumsService;
        private StadiumDTO _createStadiumDTO = new StadiumDTO
        {
            Name = "Big Wig",
            Capacity = 10000,
            Location = "London"
        };

        private StadiumDTO _updateStadiumDTO = new StadiumDTO
        {
            Name = "Big Wig",
            Capacity = 20000,
            Location = "London"
        };

        private StadiumTeamDTO _stadiumTeamDTO = new StadiumTeamDTO
        {
            StadiumId = 45,
            TeamId = 13
        };

        [TestInitialize]
        public void Initialize()
        {
            _stadiumsService = new Mock<IStadiumsService>();
            _stadiumsController = new StadiumsController(_stadiumsService.Object);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyCreateNewStadiumReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Stadium created successfully"
            };
            _stadiumsService.Setup(x => x.CreateStadium(_createStadiumDTO)).Returns(Task.FromResult(messageDTO));
            var response
                = await _stadiumsController.CreateStadium(_createStadiumDTO) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _stadiumsService.Verify(x => x.CreateStadium(It.IsAny<StadiumDTO>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Stadium created successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyUpdateStadiumReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Stadium updated successfully"
            };
            _stadiumsService.Setup(x => x.UpdateStadium(It.IsAny<int>(), _updateStadiumDTO)).Returns(Task.FromResult(messageDTO));
            var response
                = await _stadiumsController.UpdateStadium(5, _updateStadiumDTO) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _stadiumsService.Verify(x => x.UpdateStadium(It.IsAny<int>(), It.IsAny<StadiumDTO>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Stadium updated successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyDeleteStadiumReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Stadium deleted successfully"
            };
            _stadiumsService.Setup(x => x.DeleteStadium(It.IsAny<int>())).Returns(Task.FromResult(messageDTO));
            var response
                = await _stadiumsController.DeleteStadium(5) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _stadiumsService.Verify(x => x.DeleteStadium(It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Stadium deleted successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyAddTeamToStadiumReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Team added to stadium successfully"
            };
            _stadiumsService.Setup(x => x.AddTeamToStadium(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(messageDTO));
            var response
                = await _stadiumsController.AddTeamToStadium(_stadiumTeamDTO) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _stadiumsService.Verify(x => x.AddTeamToStadium(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Team added to stadium successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyRemoveTeamFromStadiumReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Team removed from stadium successfully"
            };
            _stadiumsService.Setup(x => x.RemoveTeamFromStadium(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(messageDTO));
            var response
                = await _stadiumsController.RemoveTeamFromStadium(_stadiumTeamDTO) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _stadiumsService.Verify(x => x.RemoveTeamFromStadium(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Team removed from stadium successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyReturnAStadiumGivenID()
        {
            Stadium stadium = new Stadium
            {
                StadiumId = 5,
                Name = "Big Wig",
                Capacity = 20000,
                Location = "London"
            };
            
            _stadiumsService.Setup(x => x.GetStadium(It.IsAny<int>())).Returns(Task.FromResult(stadium));
            var response
                = await _stadiumsController.GetStadium(5) as ObjectResult;
            var actualResponse = (Stadium)response.Value;
            _stadiumsService.Verify(x => x.GetStadium(It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(5, actualResponse.StadiumId);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyReturnAllStadiums()
        {
            _stadiumsService.Setup(x => x.GetAllStadiums()).Returns(GetStadiums);
            var response
                = await _stadiumsController.GetAllStadiums() as ObjectResult;
            var actualResponse = (List<Stadium>)response.Value;
            _stadiumsService.Verify(x => x.GetAllStadiums(), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(3, actualResponse.Count);
        }

        private Task<IEnumerable<Stadium>>  GetStadiums()
        {
            IEnumerable<Stadium> _stadiums =  new List<Stadium>()
            {
                new Stadium {
                    StadiumId = 5,
                    Name = "Big Wig",
                    Capacity = 20000,
                    Location = "London"
                },
                new Stadium {
                    StadiumId = 6,
                    Name = "High Angels",
                    Capacity = 15000,
                    Location = "Blackpool"
                },
                new Stadium {
                     StadiumId = 5,
                     Name = "The Heavens",
                     Capacity = 25000,
                     Location = "London"
                },
            };
            return Task.FromResult(_stadiums);
        }

        private Task<MessageDTO> GetStadiumCreatedMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Stadium created successfully"
            };
            return Task.FromResult(messageDTO);
        }

    }
}
