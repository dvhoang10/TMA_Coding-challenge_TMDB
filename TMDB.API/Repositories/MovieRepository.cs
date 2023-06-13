using Newtonsoft.Json;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;

namespace TMDB.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MovieRepository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<MovieList?> GetMovieListAsync(string language, int page)
        {
            var httpClient = httpClientFactory.CreateClient("Tmdb");
            var httpResponseMessage = await httpClient.GetAsync($"movie/popular?language={language}&page={page}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var response = await httpResponseMessage.Content.ReadAsStringAsync();
                var movieList = JsonConvert.DeserializeObject<MovieList>(response);

                return movieList;
            }

            return null;
        }

    }
}
