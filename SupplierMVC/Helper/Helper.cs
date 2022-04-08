namespace StudentMVC.Helper
{
    public class SupplierAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7152/");
            return client;
        }
    }
}
