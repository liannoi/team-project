using System.IO;

namespace TeamProject.Application
{
    public static class Consts
    {
        public static string FilmsMockPath => SearchInBaseDirectory("mock-films.json");
        public static string ActorsMockPath => SearchInBaseDirectory("mock-actors.json");
        public static string GenresMockPath => SearchInBaseDirectory("mock-genres.json");

        private static string SearchInBaseDirectory(string fileName)
        {
            var split = Path.DirectorySeparatorChar;
            var up = $"{split}..";
            return $"{Directory.GetCurrentDirectory()}{up}{up}{up}{up}{split}mocks{split}seeding{split}{fileName}";
        }
    }
}