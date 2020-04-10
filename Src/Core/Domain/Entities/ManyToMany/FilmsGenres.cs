namespace TeamProject.Domain.Entities.ManyToMany
{
    public class FilmsGenres
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }

        public Film.Film Film { get; set; }
        public Genre Genre { get; set; }
    }
}