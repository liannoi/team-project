using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TeamProject.Application.Common.Mappings;
using TeamProject.Domain.Entities;

namespace TeamProject.Application.Storage.ActorsPhotos
{
    class FilmActorDTO:IMapFrom<ActorsFilms>
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }

        public Actor Actor { get; set; }
        public Film Film { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ActorsFilms, FilmActorDTO>()
                .ForMember(x => x.ActorId, opt => opt.MapFrom(a => a.ActorId))
                .ForMember(x => x.FilmId, opt => opt.MapFrom(a => a.FilmId))
                .ForMember(x => x.Actor, opt => opt.MapFrom(a => a.Actor))
                .ForMember(x => x.Film, opt => opt.MapFrom(a => a.Film));
            profile.CreateMap<FilmActorDTO, ActorsFilms>();
        }
    }
}
