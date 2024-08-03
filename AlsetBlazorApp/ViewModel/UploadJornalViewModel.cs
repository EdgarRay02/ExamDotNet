using AlsetBlazorApp.Services;
using AlsetLibrary.DTO;
using System.Security.Cryptography.X509Certificates;

namespace AlsetBlazorApp.ViewModel
{
    public class UploadJornalViewModel
    {
        public UploadJornalViewModel(MagazineService service)
        {
            this.service = service;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public MagazineService service { get; set; }
        public async Task Upload()
        {
            UploadJornal dto = new UploadJornal();
            dto.Name = this.Name;
            dto.Email = this.Email;
            dto.LastName = this.LastName;
            dto.FilePath = this.FilePath;
            dto.Title = this.Title;
            await service.Upload(dto);
        }
    }
}
