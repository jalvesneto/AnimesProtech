using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.WEBAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Moq;
using Xunit;

namespace AnimesProtech.REPOSITORY.Tests
{
    public class DirectorControllerTests
    {
        private DirectorController _directorController;

        public DirectorControllerTests()
        {
            _directorController = new DirectorController(new Mock<ILogger<DirectorController>>().Object, new Mock<IDirectorManager>().Object);
        }

        [Fact]
        public void AddDirector_SendingValidData()
        {
            var result = _directorController.AddDirector(new RegisterDirectorDTO { Name = "Goro Taniguchi" });
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void AddDirectorAnime_SendingInValidData()
        {
            var result = _directorController.AddDirector(new RegisterDirectorDTO());
            Assert.IsNotType<CreatedResult>(result);
        }

        [Fact]
        public void RemoveDirector_SendingValidData()
        {
            var result = _directorController.RemoveDirector(2);
            Assert.IsType<NoContentResult>(result);
        }
    }
}