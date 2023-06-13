namespace TMDB.API.Models.Domain
{
    public class MovieList
    {
        public int page { get; set; }
        public List<Movie>? results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
