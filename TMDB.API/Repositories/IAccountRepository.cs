using TMDB.API.Models.Domain;

namespace TMDB.API.Repositories
{
    public interface IAccountRepository
    {
        Task<MovieList<MovieRated>?> GetMoviesRatedAsync(int accountID, string language = "en-US", int page = 1, string sortBy = "created_at.asc");
    }
}
