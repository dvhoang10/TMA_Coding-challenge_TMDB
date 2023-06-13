using AutoMapper;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;

namespace TMDB.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MovieList<Movie>, MovieListDTO<Movie>>().ReverseMap();
            CreateMap<MovieList<MovieRated>, MovieListDTO<MovieRated>>().ReverseMap();
        }
    }
}
