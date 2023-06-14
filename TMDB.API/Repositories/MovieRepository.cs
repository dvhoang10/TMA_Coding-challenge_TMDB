using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;
using TMDB.API.Utils;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TMDB.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public MovieRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClientFactory.CreateClient("Tmdb");
        }

        public async Task<MovieList<Movie>?> GetMovieListAsync(string language, int page)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"movie/top_rated?language={language}&page={page}");

            var result = await Utilities.GetResponseAsync<MovieList<Movie>>(httpResponseMessage);

            return result;
        }

        public async Task<MovieDetails?> GetMovieDetailsAsync(int movieId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"movie/{movieId}");

            var result = await Utilities.GetResponseAsync<MovieDetails>(httpResponseMessage);

            return result;
        }

        public async Task<Status?> AddRatingAsync(int movieId, AddRatingDto addRatingDto)
        {
            var data = new StringContent(JsonConvert.SerializeObject(addRatingDto), Encoding.UTF8,
        "application/json");

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync($"movie/{movieId}/rating", data);

            var result = await Utilities.GetResponseAsync<Status>(httpResponseMessage);

            return result;
        }

        public async Task<Status?> DeleteRatingAsync(int movieId)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync($"movie/{movieId}/rating");

            var result = await Utilities.GetResponseAsync<Status>(httpResponseMessage);

            return result;
        }
    }
}
