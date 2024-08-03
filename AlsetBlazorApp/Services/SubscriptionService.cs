using AlsetLibrary.DTO;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace AlsetBlazorApp.Services
{
    public class SubscriptionService
    {
        private readonly HttpClient _httpClient;

        public SubscriptionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Follow(CreateSubscription dto)
        {
            var jsonString = JsonSerializer.Serialize(dto);
            var buffer = Encoding.UTF8.GetBytes(jsonString);
            using var content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync($"/api/SubscriptionsApi/Follow", content);
        }
    }
}
