using TMDB.API.Models.Domain;

namespace TMDB.API.Repositories
{
    public interface IAccountRepository
    {
        Task<MovieList<MovieRated>?> GetMoviesRatedAsync(int accountID, string language, int page, string sortBy);
    }
}
