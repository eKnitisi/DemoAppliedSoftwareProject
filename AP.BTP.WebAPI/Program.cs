
using AP.BTP.Application.Extensions;
using AP.BTP.Infrastructure.Extensions;
using AP.BTP.WebAPI.Extensions;
using DotNetEnv;


namespace AP.BTP.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Env.Load();
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.RegisterApplication();
            builder.Services.RegisterInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            Env.Load();
            builder.Configuration["ConnectionStrings:DefaultConnection"] = Environment.GetEnvironmentVariable("CONNECTION_STRING");


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseErrorHandlingMiddleware();
            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
