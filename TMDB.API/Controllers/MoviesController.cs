using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;
using TMDB.API.Repositories;

namespace TMDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

        // GET MOVIE LIST
        [HttpGet]
        public async Task<IActionResult> GetMovieList([FromQuery] string language = "en-US", [FromQuery] int page = 1)
        {
            var movieList = await movieRepository.GetMovieListAsync(language, page);

            if (movieList == null) return NotFound();

            return Ok(mapper.Map<MovieListDTO<Movie>>(movieList));
        }

        // GET MOVIE DETAILS BY ID
        [HttpGet]
        [Route("{movie_id}")]
        public async Task<IActionResult> GetMovieDetails([FromRoute] int movie_id)
        {
            var movieDetails = await movieRepository.GetMovieDetailsAsync(movie_id);

            if (movieDetails == null) return NotFound();

            return Ok(movieDetails);
        }

        // ADD RATING
        [HttpPost]
        [Route("{movie_id}/rating")]
        public async Task<IActionResult> AddRating([FromRoute] int movie_id, [FromBody] AddRatingDTO addRatingDTO)
        {
            var statusReponse = await movieRepository.AddRatingAsync(movie_id, addRatingDTO);

            if (statusReponse == null) return NotFound();

            return Ok(statusReponse);
        }
    }
}
