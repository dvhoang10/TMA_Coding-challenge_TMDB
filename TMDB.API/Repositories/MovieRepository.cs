using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;
using static System.Net.Mime.MediaTypeNames;

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

            var result = await GetResponseAsync<MovieList>(httpResponseMessage);

            return result;
        }

        public async Task<MovieDetails?> GetMovieDetailsAsync(int id)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"movie/{id}");

            var result = await GetResponseAsync<MovieDetails>(httpResponseMessage);

            return result;
        }

        public async Task<StatusResponseDTO?> AddRatingAsync(int id, AddRatingDTO addRatingDTO)
        {
            var data = new StringContent(JsonConvert.SerializeObject(addRatingDTO), Encoding.UTF8,
        "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"movie/{id}/rating", data);

            var result = await GetResponseAsync<StatusResponseDTO>(httpResponseMessage);

            return result;
        }

        private async Task<T?> GetResponseAsync<T>(HttpResponseMessage httpResponseMessage) where T : class
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
