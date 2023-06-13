namespace TMDB.API.Models.DTO
{
    public class StatusResponseDTO
    {
        public bool Success { get; set; }
        public int Status_code { get; set; }
        public string? Status_message { get; set; }
    }
}
