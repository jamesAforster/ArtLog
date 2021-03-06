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
                    { "x-rapidapi-key", "b3d70bb793msh4e53df863c80e1ap13c999jsn53d5c3a65ae6" },
                    { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
                },
            };

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseContent);

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
                    { "x-rapidapi-key", "b3d70bb793msh4e53df863c80e1ap13c999jsn53d5c3a65ae6" },
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
