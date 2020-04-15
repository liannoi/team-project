using AutoMapper;
using TeamProject.Application.Common.Mappings;
using TeamProject.Domain.Entities.ManyToMany;

namespace TeamProject.Application.Storage.Actors
{
    public class ActorFilmLookupDto : IMapFrom<ActorsFilms>
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ActorsFilms, ActorFilmLookupDto>()
                .ForMember(d => d.FilmId, opt => opt.MapFrom(s => s.FilmId))
                .ForMember(d => d.ActorId, opt => opt.MapFrom(s => s.ActorId));
            profile.CreateMap<ActorFilmLookupDto, ActorsFilms>();
        }
    }
}