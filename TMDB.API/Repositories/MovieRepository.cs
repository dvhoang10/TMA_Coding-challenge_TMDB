using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;

namespace TMDB.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly HttpClient httpClient;

        public MovieRepository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            httpClient = httpClientFactory.CreateClient("Tmdb");
        }

        public async Task<MovieList?> GetMovieListAsync(string language, int page)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"movie/popular?language={language}&page={page}");

            var result = await GetAsync<MovieList>(httpResponseMessage);

            return result;
        }

        public async Task<MovieDetails?> GetMovieDetailsAsync(int id)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"movie/{id}");

            var result = await GetAsync<MovieDetails>(httpResponseMessage);

            return result;
        }

        private async Task<T?> GetAsync<T>(HttpResponseMessage httpResponseMessage) where T : class
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var response = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(response);

                return result;
            }

            return null;
        }
    }
}
