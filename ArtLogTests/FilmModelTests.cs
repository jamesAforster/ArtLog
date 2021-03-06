using System;
using ArtLog.Models;
using Xunit;

namespace ArtLogTests
{
    public class FilmModelTests
    {
        [Fact]
        public void Film_Has_Correct_Data_Structure()
        {
            // Arrange
            string testTitle = "Film 1";
            //string testDirector = "James Forster";
            //DateTime testReleaseDate = new DateTime(1990, 2, 3);
            //int testId = 1;

            // Act
            Film film = new Film()
            {
                Title = testTitle,
                //Director = testDirector,
                //ReleaseDate = testReleaseDate,
                //Id = testId
            };

            // Assert
            Assert.Equal(testTitle, film.Title);
            //Assert.Equal(testDirector, film.Director);
            //Assert.Equal(testReleaseDate.Year, film.ReleaseDate.Year);
            //Assert.Equal(testReleaseDate.Month, film.ReleaseDate.Month);
            //Assert.Equal(testReleaseDate.Day, film.ReleaseDate.Day);
            //Assert.Equal(testId, film.Id);
        }
    }
}
