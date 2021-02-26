using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArtLog.Services
{
    public class FilmService
    {
        public async Task<HttpResponseMessage> GetFilm()
        {
            string query = "James";
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

            return await client.SendAsync(request);
        }

        public string CreateURIQuery(string query)
        {
            return query.Replace(" ", "%20");
        }

    }
}
