namespace TeamProject.Clients.Common
{
    public static class CommonClientsDefaults
    {
        private static string WebApiAddress => "https://localhost:5001/api";
        private static string WebApiAccountsController => $"{WebApiAddress}/accounts";
        public static string WebApiAccountsControllerRegister => $"{WebApiAccountsController}/register";
        public static string WebApiAccountsControllerLogin => $"{WebApiAccountsController}/login";
        
        private static string WebApiActorsController => $"{WebApiAddress}/actors";
        public static string WebApiAcotrsControllerGetAll => $"{WebApiActorsController}/getall";
        public static string WebApiActorsControllerGet => $"{WebApiActorsController}/get/";
        public static string WebApiActorsControllerAdd => $"{WebApiActorsController}/add";
        public static string WebApiActorsControllerUpdate => $"{WebApiActorsController}/update";
        public static string WebApiActorsControllerDelete => $"{WebApiActorsController}/delete/";

    }
}