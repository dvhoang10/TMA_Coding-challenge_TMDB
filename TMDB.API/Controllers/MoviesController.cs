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
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        // GET MOVIE LIST ORDERED BY RATING
        [HttpGet]
        [Route("top_rated")]
        public async Task<IActionResult> GetMovieList([FromQuery] string language = "en-US", [FromQuery] int page = 1)
        {
            var movieList = await _movieRepository.GetMovieListAsync(language, page);

            if (movieList == null) return NotFound();

            return Ok(_mapper.Map<MovieListDto<Movie>>(movieList));
        }

        // GET MOVIE DETAILS BY ID
        [HttpGet]
        [Route("{movie_id}")]
        public async Task<IActionResult> GetMovieDetails([FromRoute] int movie_id)
        {
            var movieDetails = await _movieRepository.GetMovieDetailsAsync(movie_id);

            if (movieDetails == null) return NotFound();

            return Ok(movieDetails);
        }

        // ADD RATING
        [HttpPost]
        [Route("{movie_id}/rating")]
        public async Task<IActionResult> AddRating([FromRoute] int movie_id, [FromBody] AddRatingDto addRatingDto)
        {
            var statusReponse = await _movieRepository.AddRatingAsync(movie_id, addRatingDto);

            if (statusReponse == null) return NotFound();

            return Ok(statusReponse);
        }

        // DELETE RATING
        [HttpDelete]
        [Route("{movie_id}/rating")]
        public async Task<IActionResult> DeleteRating([FromRoute] int movie_id)
        {
            var statusReponse = await _movieRepository.DeleteRatingAsync(movie_id);

            if (statusReponse == null) return NotFound();

            return Ok(statusReponse);
        }
    }
}
