using Microsoft.OpenApi.Models;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;

namespace TMDB.API.Repositories
{
    public interface IMovieRepository
    {
        Task<MovieList?> GetMovieListAsync(string language, int page);
        Task<MovieDetails?> GetMovieDetailsAsync(int id);
        Task<StatusResponseDTO?> AddRatingAsync(int id, AddRatingDTO addRatingDTO);
    }
}
