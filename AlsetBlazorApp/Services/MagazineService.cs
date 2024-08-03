using AlsetLibrary;
using AlsetLibrary.DTO;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace AlsetBlazorApp.Services
{
    public class MagazineService
    {
        private readonly HttpClient _httpClient;

        public MagazineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Upload(UploadJornal dto)
        {
            var jsonString = JsonSerializer.Serialize(dto);
            var buffer = Encoding.UTF8.GetBytes(jsonString);
            using var content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync($"/api/MagazinesApi/Upload", content);
        }
        public async Task<MagazineRecord> GetMagazineById(int id)
        {
            var response = await _httpClient.GetAsync($"/api/MagazinesApi/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(jsonString))
            {
                return new MagazineRecord();
            }
            var arrayObject = JsonSerializer.Deserialize<MagazineRecord>(jsonString);
            return arrayObject;
        }
    }
}
