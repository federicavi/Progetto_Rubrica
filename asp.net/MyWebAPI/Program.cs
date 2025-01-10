
using Microsoft.EntityFrameworkCore;
using Prova_Rubrica.ContextDb;
using Prova_Rubrica.Models;
using Prova_Rubrica.Repositories;
using Prova_Rubrica.Services;
using System.Configuration;
using System.Text.Json.Serialization;

namespace Prova_Rubrica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration config = configurationBuilder.Build();

            // Registrazione del contesto del database
            builder.Services.AddDbContext<ProvaRubricaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            }); 
            //AddJsonOptions => permette che la proprietà riferita alla foreign key non verrà inclusa nel JSON inviato al frontend

            // Registrazione dei repository specifici
            builder.Services.AddScoped<IService, Service>();
            builder.Services.AddScoped<INumeriUtiliRepository, NumeriUtiliRepository>();
            builder.Services.AddScoped<IPersoneRepository, PersoneRepository>();

            // Configurazione CORS con indirizzo url Angular

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Middleware per gestire le richieste preflight CORS
            app.Use(async (context, next) =>
            {
                if (context.Request.Method == "OPTIONS")
                {
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                    context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
                    context.Response.StatusCode = 204;
                    await context.Response.CompleteAsync();
                }
                else
                {
                    await next();
                }
            });


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Applica la politica CORS qui
            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
