using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;
using TMDB.API.Repositories;

namespace TMDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;

        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        // GET RATED MOVIES
        [HttpGet]
        [Route("{account_id}/rated/movies")]
        public async Task<IActionResult> GetMoviesRated([FromRoute] int account_id = 13046451, [FromQuery] string language = "en-US", [FromQuery] int page = 1, [FromQuery] string sort_by = "created_at.asc")
        {
            var movieList = await accountRepository.GetMoviesRatedAsync(account_id, language, page, sort_by);

            if (movieList == null) return NotFound();

            return Ok(mapper.Map<MovieListDTO<MovieRated>>(movieList));
        }
    }
}
