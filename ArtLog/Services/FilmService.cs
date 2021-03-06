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
        public HttpClient client = new HttpClient();
        public Secrets secrets = new Secrets();

        public string CreateURIQuery(string query)
        {
            return query.Replace(" ", "%20");
        }

        public async Task<Film> GetFilm(string id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?i={id}&r=json"),
                Headers =
                {
                    { "x-rapidapi-key", $"{secrets.RapidApiKey}" },
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                },
            };

            HttpResponseMessage response = await client.SendAsync(request);

            string responseContent = await response.Content.ReadAsStringAsync();

            Film result = JsonConvert.DeserializeObject<Film>(responseContent);

            return result;
        }

        public async Task<Payload> GetFilms(string query)
        {
            string searchQuery = CreateURIQuery(query);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-imdb-alternative.p.rapidapi.com/?s={searchQuery}&page=1&r=json"),
                Headers =
                {
                    { "x-rapidapi-key", $"{secrets.RapidApiKey}" },
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                }
            };

            HttpResponseMessage response = await client.SendAsync(request);

            string responseContent = await response.Content.ReadAsStringAsync();

            Payload result = JsonConvert.DeserializeObject<Payload>(responseContent);

            return result;
        }
    }
}
