namespace TMDB.API.Models.Domain
{
    public class Status
    {
        public bool Success { get; set; }
        public int Status_code { get; set; }
        public string? Status_message { get; set; }
    }
}
