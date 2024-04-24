using Helldivers2.MAUI.Models;
using Newtonsoft.Json;

namespace Helldivers2.MAUI.Services
{
    public interface IHelldiversApiService
    {
        Task<List<Campaign>> GetWarCampaign();
        //TODO: Add other api calls
    }

    public class HelldiversApiService : IHelldiversApiService
    {
        static readonly HttpClient _httpClient = new HttpClient();
        static readonly JsonSerializer _serializer = new JsonSerializer();

        public async Task<List<Campaign>> GetWarCampaign()
        {
            return await SerializeJson<List<Campaign>>(Constants.WarCampaignUrl);
        }

        async Task<T> SerializeJson<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            using (response)
            {
                response.EnsureSuccessStatusCode();

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    return _serializer.Deserialize<T>(json);
                }
            }
        }
    }
}