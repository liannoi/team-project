using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamProject.Clients.Common.Models.Storage.Actors;

namespace TeamProject.Clients.WebUI.Models
{
    public class ActorViewModel
    {
        public ActorBindingModel Actor { get; set; }

        public IEnumerable<int> SelectedFilms { get; set; }
        public IEnumerable<SelectListItem> Films { get; set; }
        public bool IsNopeFilms { get; set; }
    }
}