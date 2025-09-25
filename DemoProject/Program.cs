using AP.BTP.Application.Extensions;
using AP.BTP.Infrastructure.Contexts;
using AP.BTP.Infrastructure.Extensions;
using DemoProject.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DemoProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.RegisterInfrastructure();
            builder.Services.RegisterApplication();
            builder.Services.AddControllers();
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            using (SqlConnection conn = new SqlConnection("Server=LAPTOP-PVNO4J0S;Database=DemoProject;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Verbinding succesvol!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Verbinding mislukt: " + ex.Message);
                }
            }
            app.Run();
        }
    }
}
