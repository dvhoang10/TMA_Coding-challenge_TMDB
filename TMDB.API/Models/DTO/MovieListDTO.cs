namespace TMDB.API.Models.DTO
{
    public class MovieListDTO<T> where T : class
    {
        public List<T>? results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
