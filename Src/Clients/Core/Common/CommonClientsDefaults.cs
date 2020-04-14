namespace TeamProject.Clients.Common
{
    public static class CommonClientsDefaults
    {
        private static string WebApiAddress => "https://localhost:5001/api";
        private static string WebApiAccountsController => $"{WebApiAddress}/accounts";
        public static string WebApiAccountsControllerRegister => $"{WebApiAccountsController}/register";
        public static string WebApiAccountsControllerLogin => $"{WebApiAccountsController}/login";

        private static string WebApiActorsController => $"{WebApiAddress}/actors";
        public static string WebApiActorsControllerGetAll => $"{WebApiActorsController}/getall";
        public static string WebApiActorsControllerGet => $"{WebApiActorsController}/get";
        public static string WebApiActorsControllerAdd => $"{WebApiActorsController}/add";
        public static string WebApiActorsControllerUpdate => $"{WebApiActorsController}/update";
        public static string WebApiActorsControllerDelete => $"{WebApiActorsController}/delete";

        private static string WebApiFilmsController => $"{WebApiAddress}/films";
        public static string WebApiFilmsControllerGetAll => $"{WebApiFilmsController}/getall";
        public static string WebApiFilmsControllerGet => $"{WebApiFilmsController}/get";
        public static string WebApiFilmsControllerCreate => $"{WebApiFilmsController}/create";
        public static string WebApiFilmsControllerUpdate => $"{WebApiFilmsController}/update";
        public static string WebApiFilmsControllerDelete => $"{WebApiFilmsController}/delete";
    }
}