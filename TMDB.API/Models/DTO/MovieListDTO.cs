namespace TMDB.API.Models.DTO
{
    public class MovieListDto<T> where T : class
    {
        public List<T>? Results { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }
}
