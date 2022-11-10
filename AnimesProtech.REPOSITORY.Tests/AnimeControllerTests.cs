using AnimesProtech.DTO.AnimesDTO;
using AnimesProtech.DTO.DirectorDTO;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.WEBAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Moq;

using Xunit;

namespace AnimesProtech.WEBAPI.Tests
{
    public class AnimeControllerTests
    {

        private AnimeController _animeController;
        private DirectorController _directorController;

        public AnimeControllerTests()
        {
            _animeController = new AnimeController(new Mock<ILogger<AnimeController>>().Object, new Mock<IAnimeManager>().Object);

            _directorController = new DirectorController(new Mock<ILogger<DirectorController>>().Object, new Mock<IDirectorManager>().Object);
        }

        [Fact]
        public void AddAnime_SendingValidData()
        {
            var result = _animeController.AddAnime(new RegisterAnimeDTO { Name = "One Piece", Description = "Pirata que estica", IdDirector = 1 });
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void AddAnime_SendingInValidData()
        {
            var result = _animeController.AddAnime(new RegisterAnimeDTO { Name = "", Description = "Pirata que estica", IdDirector = 1});
            Assert.IsNotType<CreatedResult>(result);
        }

        [Fact]
        public void RemoveAnime_SendingValidData()
        {
            var result = _animeController.RemoveAnime(2);
            Assert.IsType<NoContentResult>(result);
        }

    }
}
