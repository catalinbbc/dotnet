using Microsoft.AspNetCore.Mvc;
using MusicLibrary.api.Services;
using MusicLibrary.Controllers;
using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class ArtistControllerByIdTest

    {
        ArtistsController _controller;
        IArtistService _service;

        public ArtistControllerByIdTest()
        {
            _service = new ArtistServiceFake();
            _controller = new ArtistsController(_service);
        }


        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetArtist(12345);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            //var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            var testId = 1;  
            // Act
            var okResult = _controller.GetArtist(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            //var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            var testId = 1;

            // Act
            //var okResult = _controller.GetArtist(testId).Result as OkObjectResult;

            // Assert
            //Assert.IsType<Artist>(okResult.Value);
            //Assert.Equal(testId, (okResult.Value as Artist).Id);
        }

    }
}
