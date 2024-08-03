using AlsetLibrary.DTO;
using System.Text.Json;

namespace AlsetBlazorApp.Services
{
    public class ResearcherService
    {
        private readonly HttpClient _httpClient;

        public ResearcherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ResearcherRecord>> GetResearchersAsync()
        {
            var response = await _httpClient.GetAsync("api/ResearchersApi");
            var jsonString = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(jsonString))
            {
                return new List<ResearcherRecord>();
            }
            var arrayObject = JsonSerializer.Deserialize<IList<ResearcherRecord>>(jsonString);
            return arrayObject;
        }
    }
}
