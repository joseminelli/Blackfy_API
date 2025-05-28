using blackfy_API.Models;
using System.Text.Json;
using System.Net.Http;


namespace blackfy_API.Services
{
    public class ExternalLinkService
    {
        private readonly HttpClient httpClient;

        public ExternalLinkService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<Driver?> GetDriver(int driverNumber)
        {
            var result = await httpClient.GetAsync("https://api.openf1.org/v1/drivers?driver_number=" + driverNumber + "&session_key=9158");

            if (!result.IsSuccessStatusCode)
            {
                return null;
            }

            var jsonResult = await result.Content.ReadAsStringAsync();

            //traduz o json da api para um Driver
            var driverResult = JsonSerializer.Deserialize<List<Driver>>(jsonResult, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var driver = driverResult?.FirstOrDefault();

            return driver ?? null;
        }
    }
}
