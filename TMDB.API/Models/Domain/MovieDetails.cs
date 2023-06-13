namespace TMDB.API.Models.Domain
{
    public class MovieDetails : Movie
    {
        public Collection? Belongs_to_collection { get; set; }
        public long Budget { get; set; }
        public string? Homepage { get; set; }
        public string? Imdb_id { get; set; }
        public List<Company>? Production_companies { get; set; }
        public List<ProductionCountry>? Production_countries { get; set; }
        public string? Release_date { get; set; }
        public long Revenue { get; set; }
        public int Runtime { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
    }
}
