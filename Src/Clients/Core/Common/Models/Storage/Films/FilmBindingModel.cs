using System;

namespace TeamProject.Clients.Common.Models.Storage.Films
{
    public class FilmBindingModel : ValueObject
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public DateTime PublishYear { get; set; }
        public string Description { get; set; }
    }
}