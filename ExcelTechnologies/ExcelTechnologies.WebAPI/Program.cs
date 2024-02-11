
using ExcelTechnologies.BAL.Allergies;
using ExcelTechnologies.BAL.DiseaseInformation;
using ExcelTechnologies.BAL.NCD;
using ExcelTechnologies.BAL.PatientInformation;
using ExcelTechnologies.DAL;
using ExcelTechnologies.DAL.Allergies;
using ExcelTechnologies.DAL.DiseaseInformation;
using ExcelTechnologies.DAL.NCD;
using ExcelTechnologies.WebAPI.PatientInformation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace ExcelTechnologies.WebAPI
{
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

            // Inject IConfiguration into the Startup class
            var configuration = builder.Configuration;

            // Configure DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<INCDRepository, NCDRepository>();
            builder.Services.AddScoped<IAllergiesRepository, AllergiesReppository>();
            builder.Services.AddScoped<IDiseaseInformationRepository, DiseaseInformationRepository>();
            builder.Services.AddScoped<IPatientInformationRepository, PatientInformationRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}