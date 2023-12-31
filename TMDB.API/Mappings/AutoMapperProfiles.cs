﻿using AutoMapper;
using TMDB.API.Models.Domain;
using TMDB.API.Models.DTO;

namespace TMDB.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MovieList<Movie>, MovieListDto<Movie>>().ReverseMap();
            CreateMap<MovieList<MovieRated>, MovieListDto<MovieRated>>().ReverseMap();
        }
    }
}
