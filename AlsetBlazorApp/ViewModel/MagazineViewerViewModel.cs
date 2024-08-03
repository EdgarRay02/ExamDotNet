using AlsetBlazorApp.Services;
using AlsetLibrary.DTO;
using System.Security.Cryptography.X509Certificates;

namespace AlsetBlazorApp.ViewModel
{
    public class MagazineViewerViewModel
    {
        public MagazineViewerViewModel(MagazineService service)
        {
            this.Service = service;
        }
        MagazineService Service { get; set; }
        public int Id { get; set; }
        public MagazineRecord Record { get; set; }
        public async Task Load()
        {
            Record = await Service.GetMagazineById(Id);
        }
        public string GetData(string path)
        {
            var bytes = File.ReadAllBytes(path);
            string file = Convert.ToBase64String(bytes);
            return "data:application/pdf;base64," + $"{file}#toolbar=0&pointer-events: none";
        }
    }
}
