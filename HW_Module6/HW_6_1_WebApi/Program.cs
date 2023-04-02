using HW_6_1_WebApi.Core;
using HW_6_1_WebApi.Infrastructure;

namespace HW_6_1_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.Configure<AppConfiguration>(builder.Configuration);

            // Dependencies
            builder.Services.AddSingleton<IPeopleRepository, InMemoryPeopleRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}