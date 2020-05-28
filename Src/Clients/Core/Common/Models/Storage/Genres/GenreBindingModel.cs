using System;
using System.Collections.Generic;
using System.Text;

namespace TeamProject.Clients.Common.Models.Storage.Genres
{
    public class GenreBindingModel:ValueObject
    {
        public int GenreId { get; set; }
        public string Title { get; set; }
    }
}
