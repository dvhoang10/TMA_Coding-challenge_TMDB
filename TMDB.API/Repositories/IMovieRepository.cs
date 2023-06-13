using TMDB.API.Models.Domain;

namespace TMDB.API.Repositories
{
    public interface IMovieRepository
    {
        Task<MovieList?> GetMovieListAsync(string language, int page);
    }
}
