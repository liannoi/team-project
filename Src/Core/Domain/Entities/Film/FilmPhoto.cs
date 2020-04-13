﻿namespace TeamProject.Domain.Entities.Film
{
    public class FilmPhoto
    {
        public int PhotoId { get; set; }
        public int FilmId { get; set; }
        public string Path { get; set; }

        public Film Film { get; set; }
    }
}