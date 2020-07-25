using Microsoft.AspNetCore.Mvc;
using MusicLibrary.api.Services;
using MusicLibrary.Controllers;
using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class ArtistControllerTest
    {
        ArtistsController _controller;
        IArtistService _service;

        public ArtistControllerTest()
        {
            _service = new ArtistServiceFake();
            _controller = new ArtistsController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetArtists();

            // Assert
                Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetArtists().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Artist>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
