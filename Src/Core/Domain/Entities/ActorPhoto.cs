namespace TeamProject.Domain.Entities
{
    public class ActorPhoto
    {
        public int PhotoId { get; set; }
        public int ActorId { get; set; }
        public string Path { get; set; }

        public Actor Actor { get; set; }
    }
}