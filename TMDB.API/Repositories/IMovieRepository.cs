using Microsoft.OpenApi.Models;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;

namespace TMDB.API.Repositories
{
    public interface IMovieRepository
    {
        Task<MovieList<Movie>?> GetMovieListAsync(string language = "en-US", int page = 1);
        Task<MovieDetails?> GetMovieDetailsAsync(int movieID);
        Task<Status?> AddRatingAsync(int movieID, AddRatingDTO addRatingDTO);
        Task<Status?> DeleteRatingAsync(int movieID);
    }
}
