using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ArtLog.Models;
using Newtonsoft.Json;

namespace ArtLog.Services
{
    public class FilmService
    {
        public string CreateURIQuery(string query)
        {
            return query.Replace(" ", "%20");
        }

        public async Task<Film> GetFilm(string id)
        {
            string searchQuery = CreateURIQuery(id);

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?i={searchQuery}&r=json"),
                Headers =
                {
                    { "x-rapidapi-key", "688f175b74mshb3a5a51070d4c7ap1ed0b5jsn8c9fe9826afb" },
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                },
            };
            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseContent);

            Film json = JsonConvert.DeserializeObject<Film>(responseContent);

            Debug.WriteLine("Yeah");
            return json;

        }

        public async Task<Payload> GetFilms(string query)
        {
            string searchQuery = CreateURIQuery(query);

            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?s={searchQuery}&page=1&r=json"),
                Headers =

            {
                { "x-rapidapi-key", "688f175b74mshb3a5a51070d4c7ap1ed0b5jsn8c9fe9826afb" },
                { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
            }
            };

            HttpResponseMessage response = await client.SendAsync(request);

            string responseContent = await response.Content.ReadAsStringAsync();

            Payload json = JsonConvert.DeserializeObject<Payload>(responseContent);

            return json;
        }
    }
}
