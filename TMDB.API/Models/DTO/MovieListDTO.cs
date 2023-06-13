using TMDB.API.Models.Domain;

namespace TMDB.API.Models.DTO
{
    public class MovieListDTO
    {
        public List<Movie>? results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
