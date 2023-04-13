using HW_6_1_WebApi.Core;
using HW_6_1_WebApi.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration["IdentityBaseUrl"];
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            builder.Services.AddLocalization();
            //builder.Services.AddMvc(options =>
            //{
            //    options.Filters.Add<LoggerFilter>();
            //    options.Filters.Add<ExeptionFilter>();
            //});

            builder.Services.AddCors();

            // Dependencies
            builder.Services.AddSingleton<IPeopleRepository, InMemoryPeopleRepository>();

            var app = builder.Build();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}