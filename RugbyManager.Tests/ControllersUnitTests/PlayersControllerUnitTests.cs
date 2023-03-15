using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RugbyManager.Services.Players;

namespace RugbyManager.Tests.ControllersUnitTests
{
    [TestClass]
    public class PlayersControllerUnitTests
    {
        private Mock<IPlayersService> _playersService;

        [TestInitialize]
        public void Initialize()
        {
            _playersService = new Mock<IPlayersService>();
        }

        [TestMethod]
        public void ShouldCreateNewPlayerReturnsMessageDTO()
        {

        }

        [TestMethod]
        public void ShouldGetAllPlayersReturnsPlayers()
        {

        }

    }
}
