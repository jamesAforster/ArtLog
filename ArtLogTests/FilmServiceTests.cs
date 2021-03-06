using System;
using System.Collections.Generic;
using ArtLog.Models;
using ArtLog.Services;
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
            string query = "The NeverEnding Story";

            // Act
            Payload actual = await filmService.GetFilms(query);

            // Assert
            Assert.IsType<List<Film>>(actual.Search);
        }

        [Fact]
        public async void GetFilms_Returns_Correct_Film_From_Search()
        {
            // Arrange
            var filmService = new FilmService();
            string query = "The NeverEnding Story";

            // Act
            Payload actual = await filmService.GetFilms(query);

            // Assert
            Assert.Equal(actual.Search[0].Title, query);
        }

        [Fact]
        public async void GetFilm_By_ID_Returns_Correct_Film()
        {
            // Arrange
            var filmService = new FilmService();
            string id = "tt0088323";
            string expectedTitle = "The NeverEnding Story";

            // Act
            Film actual = await filmService.GetFilm(id);

            // Assert
            Assert.Equal(actual.Title, expectedTitle);
        }
    }
}
