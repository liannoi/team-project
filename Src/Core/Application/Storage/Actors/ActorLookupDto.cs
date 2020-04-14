using System;
using System.Collections.Generic;
using AutoMapper;
using TeamProject.Application.Common.Mappings;
using TeamProject.Application.Storage.ActorsPhotos;
using TeamProject.Application.Storage.Films;
using TeamProject.Clients.WebApi.Models.Core.Returnable;
using TeamProject.Domain.Entities.Actor;

namespace TeamProject.Application.Storage.Actors
{
    public class ActorLookupDto : ValueObject, IMapFrom<Actor>
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public IEnumerable<ActorPhotoLookupDto> Photos { get; set; }
        public IEnumerable<FilmLookupDto> Films { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Actor, ActorLookupDto>()
                .ForMember(d => d.ActorId, opt => opt.MapFrom(s => s.ActorId))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.Birthday, opt => opt.MapFrom(s => s.Birthday));
            profile.CreateMap<ActorLookupDto, Actor>();
        }
    }
}