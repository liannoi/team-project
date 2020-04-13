using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TeamProject.Application.Common.Mappings;
using TeamProject.Domain.Entities;
using TeamProject.Domain.Entities.Film;

namespace TeamProject.Application.Storage.Films
{
    public class FilmDTO: IMapFrom<Film>
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public DateTime PublishYear { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmDTO>();
                //.ForMember(x => x.FilmId, opt => opt.MapFrom(f => f.FilmId))
                //.ForMember(x => x.Title, opt => opt.MapFrom(f => f.Title))
                //.ForMember(x => x.PublishYear, opt => opt.MapFrom(f => f.PublishYear))
                //.ForMember(x => x.Description, opt => opt.MapFrom(f => f.Description));
            profile.CreateMap<FilmDTO, Film>();
        }
    }
}
