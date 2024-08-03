using AlsetBlazorApp.Data;
using AlsetBlazorApp.Services;
using AlsetBlazorApp.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AlsetBlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddHttpClient<MagazineService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7023");
            });
            builder.Services.AddHttpClient<ResearcherService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7023");
            });
            builder.Services.AddHttpClient<SubscriptionService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7023");
            });

            builder.Services.AddTransient<UploadJornalViewModel>();
            builder.Services.AddTransient<ListResearcherViewModel>();
            builder.Services.AddTransient<MagazineViewerViewModel>();
            builder.Services.AddTransient<SubscriptionViewModel>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}