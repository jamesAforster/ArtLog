using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ArtLog.Models;
using Newtonsoft.Json;

namespace ArtLog.Services
{
    public class FilmService
    {
        public async Task<Root> GetFilms(string query)
        {
            string searchQuery = CreateURIQuery(query);

            var client = new HttpClient();

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

            var response = await client.SendAsync(request);

            string stringy = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<Root>(stringy);

            return json;
        }

        public string CreateURIQuery(string query)
        {
            return query.Replace(" ", "%20");
        }
    }
}
