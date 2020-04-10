using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TeamProject.Application.Common.Mappings;
using TeamProject.Domain.Entities;

namespace TeamProject.Application.Storage.Genere
{
    public class GenreDTO:IMapFrom<Genre>
    {
        public int GenreId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreDTO>()
                .ForMember(x => x.GenreId, opt => opt.MapFrom(r => r.GenreId))
                .ForMember(x => x.Title, opt => opt.MapFrom(r => r.Title));
            profile.CreateMap<GenreDTO, Genre>();

        }
        
    }
}
