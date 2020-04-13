﻿using System;

namespace TeamProject.Clients.WebUI.Common.Models.Returnable
{
    public class ActorReturnModel
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}