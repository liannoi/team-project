using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Application.Storage.Actors;
using TeamProject.Application.Storage.Films;
using TeamProject.Application.Storage.Genres;

namespace TeamProject.Clients.WebApi.ViewModels.Films
{
    public class FilmAtorsGenresViewModel
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public DateTime PublishYear { get; set; }
        public string Description { get; set; }
        public ICollection<ActorLookupDto> _actors { get; set; }
        public ICollection<GenreLookupDto> _genres { get; set; }
        //public ICollection<PhotoDTO> _photos { get; set; }
        //public static List<FilmAtorsGenresViewModel> GetFilmViewModel(IBusinessService<ActorLookupDto> _actorRepository,
        //    IBusinessService<GenreDTO> _filmRepository,
        //    IBusinessService<FilmDTO> _repository,
        //    IBusinessService<FilmActorDTO> _repository)
        //{
        //    var films = _filmRepository.Select();
        //    List<FilmAtorsGenresViewModel> collection = new List<FilmAtorsGenresViewModel>();
        //    foreach (var item in films)
        //    {
        //        collection.Add(new FilmAtorsGenresViewModel
        //        {
        //            FilmId=item.f
        //        })
        //    }
        //}
    }
}
