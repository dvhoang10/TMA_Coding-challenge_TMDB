using TMDB.API.Models.Domain;

namespace TMDB.API.Repositories
{
    public interface IAccountRepository
    {
        Task<MovieList<MovieRated>?> GetMoviesRatedAsync(int accountId, string language, int page, string sortBy);
    }
}
