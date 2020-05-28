namespace TeamProject.Domain.Entities.ManyToMany
{
    public class ActorsFilms
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }

        public Actor.Actor Actor { get; set; }
        public Film.Film Film { get; set; }
    }
}