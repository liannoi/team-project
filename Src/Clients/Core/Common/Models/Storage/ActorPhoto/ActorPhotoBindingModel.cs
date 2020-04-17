using System;
using System.Collections.Generic;
using System.Text;

namespace TeamProject.Clients.Common.Models.Storage.ActorPhoto
{
    public class ActorPhotoBindingModel
    {
        public int PhotoId { get; set; }
        public int ActorId { get; set; }
        public string Path { get; set; }
    }
}
