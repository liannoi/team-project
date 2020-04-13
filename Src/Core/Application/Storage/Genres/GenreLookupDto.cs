using AutoMapper;
using TeamProject.Application.Common.Mappings;
using TeamProject.Domain.Entities;

namespace TeamProject.Application.Storage.Genres
{
    public class GenreLookupDto : IMapFrom<Genre>
    {
        public int GenreId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreLookupDto>()
                .ForMember(x => x.GenreId, opt => opt.MapFrom(r => r.GenreId))
                .ForMember(x => x.Title, opt => opt.MapFrom(r => r.Title));
            profile.CreateMap<GenreLookupDto, Genre>();
        }
    }
}