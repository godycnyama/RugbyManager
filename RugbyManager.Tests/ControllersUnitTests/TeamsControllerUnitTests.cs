using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RugbyManager.API.TeamsAPI;
using RugbyManager.Domain.DTOModels;
using RugbyManager.Domain.Models;
using RugbyManager.Services.Teams;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RugbyManager.Tests.ControllersUnitTests
{
    [TestClass]
    public class TeamsControllerUnitTests
    {
        private TeamsController _teamsController;
        private Mock<ITeamsService>  _teamsService;
        private TeamDTO _createTeamDTO = new TeamDTO
        {
            Name = "Eagles",
            Description = "Rugby team for women"
        };

        private TeamDTO _updateTeamDTO = new TeamDTO
        {
            Name = "Eagles",
            Description = "Rugby team for men"
        };

        [TestInitialize]
        public void Initialize()
        {
            _teamsService = new Mock<ITeamsService>();
            _teamsController = new TeamsController(_teamsService.Object);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyCreateNewTeamReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Team created successfully"
            };
            _teamsService.Setup(x => x.CreateTeam(_createTeamDTO)).Returns(Task.FromResult(messageDTO));
            var response
                = await _teamsController.CreateTeam(_createTeamDTO) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _teamsService.Verify(x => x.CreateTeam(It.IsAny<TeamDTO>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Team created successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyUpdateTeamReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Team updated successfully"
            };
            _teamsService.Setup(x => x.UpdateTeam(It.IsAny<int>(), _updateTeamDTO)).Returns(Task.FromResult(messageDTO));
            var response
                = await _teamsController.UpdateTeam(5, _updateTeamDTO) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _teamsService.Verify(x => x.UpdateTeam(It.IsAny<int>(), It.IsAny<TeamDTO>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Team updated successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyDeleteTeamReturnsMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Team deleted successfully"
            };
            _teamsService.Setup(x => x.DeleteTeam(It.IsAny<int>())).Returns(Task.FromResult(messageDTO));
            var response
                = await _teamsController.DeleteTeam(5) as ObjectResult;
            var actualResponse = (MessageDTO)response.Value;
            _teamsService.Verify(x => x.DeleteTeam(It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual("Team deleted successfully", actualResponse.Message);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyReturnATeamGivenID()
        {
            Team team = new Team
            {
                TeamId = 5,
                Name = "Eagles",
                Description = "Rugby team for men"
            };
            
            _teamsService.Setup(x => x.GetTeam(It.IsAny<int>())).Returns(Task.FromResult(team));
            var response
                = await _teamsController.GetTeam(5) as ObjectResult;
            var actualResponse = (Team)response.Value;
            _teamsService.Verify(x => x.GetTeam(It.IsAny<int>()), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(5, actualResponse.TeamId);
        }

        [TestMethod]
        public async Task ShouldSuccessfullyReturnAllTeams()
        {
            Team team = new Team
            {
                Name = "Eagles",
                Description = "Rugby team for men"
            };

            _teamsService.Setup(x => x.GetAllTeams()).Returns(GetTeams);
            var response
                = await _teamsController.GetAllTeams() as ObjectResult;
            var actualResponse = (List<Team>)response.Value;
            _teamsService.Verify(x => x.GetAllTeams(), Times.Once);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(3, actualResponse.Count);
        }

        private Task<IEnumerable<Team>>  GetTeams()
        {
            IEnumerable<Team> _teams =  new List<Team>()
            {
                new Team {
                    Name = "Eagles",
                    Description = "Rugby team for men"
                },
                new Team {
                    Name = "Lions",
                    Description = "Rugby team for men"
                },
                new Team {
                    Name = "Queens",
                    Description = "Rugby team for women"
                },
            };
            return Task.FromResult(_teams);
        }

        private Task<MessageDTO> GetTeamCreatedMessageDTO()
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Message = "Team created successfully"
            };
            return Task.FromResult(messageDTO);
        }

    }
}
