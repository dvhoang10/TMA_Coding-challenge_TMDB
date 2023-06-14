using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using TMDB.API.Models.Domain;
using TMDB.API.Utils;

namespace TMDB.API.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public AccountRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClientFactory.CreateClient("Tmdb");
        }

        public async Task<MovieList<MovieRated>?> GetMoviesRatedAsync(int accountId, string language = "en-US", int page = 1, string? sortBy = null)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"account/{accountId}/rated/movies?language={language}&page={page}&sort_by={sortBy}");

            var result = await Utilities.GetResponseAsync<MovieList<MovieRated>>(httpResponseMessage);

            return result;
        }
    }
}
