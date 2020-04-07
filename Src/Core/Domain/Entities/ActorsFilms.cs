﻿namespace TeamProject.Domain.Entities
{
    public class ActorsFilms
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }

        public Actor Actor { get; set; }
        public Film Film { get; set; }
    }
}