using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Application.Storage.Genere;
using TeamProject.Domain.Entities;

namespace TeamProject.Application.Storage.Genres
{
    public class GenreRepository : BaseBusinessService<Genre, GenreDTO>
    {
        public GenreRepository(IDataService<Genre> dataService, IMapper mapper) : base(dataService, mapper)
        {
        }
    }
}
