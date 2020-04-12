namespace TeamProject.Clients.Common
{
    public static class CommonClientsDefaults
    {
        private static string WebApiAddress => "https://localhost:5001/api";
        private static string WebApiAccountsController => $"{WebApiAddress}/accounts";
        public static string WebApiAccountsControllerRegister => $"{WebApiAccountsController}/register";
        public static string WebApiAccountsControllerLogin => $"{WebApiAccountsController}/login";
    }
}