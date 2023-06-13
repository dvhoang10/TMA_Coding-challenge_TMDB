namespace TMDB.API.Models.Domain
{
    public class MovieList<T>
    {
        public int Page { get; set; }
        public List<T>? Results { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }
}
