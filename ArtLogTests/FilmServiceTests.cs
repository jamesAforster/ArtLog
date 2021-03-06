using System;
using System.Collections.Generic;
using System.Net.Http;
using ArtLog.Models;
using ArtLog.Services;
using Newtonsoft.Json;
using Xunit;

namespace ArtLogTests
{
    public class FilmServiceTests
    {
        [Fact]
        public async void GetFilms_Returns_A_List_Of_Films()
        {
            // Arrange
            var filmService = new FilmService();
            string query = "The Neverending Story";

            // Act
            Root actual = await filmService.GetFilms(query);

            // Assert
            Assert.IsType<List<Film>>(actual.Search);
        }
    }
}
