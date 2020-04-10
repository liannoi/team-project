using System.IO;

namespace TeamProject.Persistence
{
    public static class Consts
    {
        public static string DatabaseNameInConnectionString => "FilmsDatabase";
        public static string IdentityDatabaseNameInConnectionString => "DefaultConnection";
        public static string Environment => "ASPNETCORE_ENVIRONMENT";

        public static string ApplicationStartDirectory
        {
            get
            {
                var separator = Path.DirectorySeparatorChar;
                return
                    $"{Directory.GetCurrentDirectory()}{separator}..{separator}Clients{separator}Core{separator}WebAPI";
            }
        }
    }
}