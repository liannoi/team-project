using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Domain.Entities;
using TeamProject.Domain.Entities.Film;

namespace TeamProject.Application.Storage.Films
{
    class FilmRepository:BaseBusinessService<Film,FilmDTO>
    {
        public FilmRepository(IDataService<Film> dataService, IMapper mapper):base(dataService,mapper)
        {
        }
    }
}
