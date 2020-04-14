using System;
using AutoMapper;
using TeamProject.Application.Common.Mappings;
using TeamProject.Domain.Entities.Film;

namespace TeamProject.Application.Storage.Films
{
    public class FilmLookupDto : IMapFrom<Film>
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public DateTime PublishYear { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmLookupDto>()
                .ForMember(d => d.FilmId, opt => opt.MapFrom(s => s.FilmId))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.PublishYear, opt => opt.MapFrom(s => s.PublishYear))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
            profile.CreateMap<FilmLookupDto, Film>();
        }
    }
}