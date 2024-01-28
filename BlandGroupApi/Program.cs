
using BlandGroupApi.Interfaces;
using BlandGroupApi.Services;
using BlandGroupShared.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BlandGroupApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                                  .AllowAnyMethod()
                                  .AllowAnyHeader()
                                  .WithExposedHeaders("Access-Control-Allow-Origin")
                                  //.AllowAnyOrigin() // <- allowes all!
                                  .WithOrigins("http://localhost:4200", "https://localhost:4200")
                                  );
        });

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bland Group Api", Version = "v1" });
        });

        builder.Services.AddScoped<IFileService,FileService>();
        builder.Services.AddScoped<IPlateReaderService, PlateReaderService>();

        builder.Services.AddHostedService<CameraBackgroundService>();

        var app = builder.Build();

        app.UseCors("CorsPolicy");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

