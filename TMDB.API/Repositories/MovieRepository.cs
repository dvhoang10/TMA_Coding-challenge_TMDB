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
        private readonly IHttpClientFactory httpClientFactory;
        private readonly HttpClient httpClient;

        public MovieRepository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            httpClient = httpClientFactory.CreateClient("Tmdb");
        }

        public async Task<MovieList<Movie>?> GetMovieListAsync(string language, int page)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"movie/popular?language={language}&page={page}");

            var result = await Utilities.GetResponseAsync<MovieList<Movie>>(httpResponseMessage);

            return result;
        }

        public async Task<MovieDetails?> GetMovieDetailsAsync(int movieID)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"movie/{movieID}");

            var result = await Utilities.GetResponseAsync<MovieDetails>(httpResponseMessage);

            return result;
        }

        public async Task<Status?> AddRatingAsync(int movieID, AddRatingDTO addRatingDTO)
        {
            var data = new StringContent(JsonConvert.SerializeObject(addRatingDTO), Encoding.UTF8,
        "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"movie/{movieID}/rating", data);

            var result = await Utilities.GetResponseAsync<Status>(httpResponseMessage);

            return result;
        }

        public async Task<Status?> DeleteRatingAsync(int movieID)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync($"movie/{movieID}/rating");

            var result = await Utilities.GetResponseAsync<Status>(httpResponseMessage);

            return result;
        }
    }
}
