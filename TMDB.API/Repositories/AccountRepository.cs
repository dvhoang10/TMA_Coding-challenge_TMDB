using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using TMDB.API.Models.Domain;
using TMDB.API.Utils;

namespace TMDB.API.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly HttpClient httpClient;

        public AccountRepository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            httpClient = httpClientFactory.CreateClient("Tmdb");
        }

        public async Task<MovieList<MovieRated>?> GetMoviesRatedAsync(int accountID, string language = "en-US", int page = 1, string? sortBy = null)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"account/{accountID}/rated/movies?language={language}&page={page}&sort_by={sortBy}");

            var result = await Utilities.GetResponseAsync<MovieList<MovieRated>>(httpResponseMessage);

            return result;
        }
    }
}
