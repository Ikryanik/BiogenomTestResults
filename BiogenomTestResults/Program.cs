using BiogenomTestResults.DbContext;
using BiogenomTestResults.Repositories;
using BiogenomTestResults.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BiogenomTestResults
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var appConfig = new AppConfig(builder);
            builder.Services.AddSingleton(appConfig);

            builder.Services.AddScoped<NecessaryFoodSupplementRepository>();
            builder.Services.AddScoped<HealthIndicatorService>();
            builder.Services.AddScoped<HealthIndicatorResultsRepository>();
            builder.Services.AddScoped<FoodSupplementsService>();

            builder.Services.AddControllers();
            builder.Services.AddDbContext<BopgenomdbContext>(options =>
                options.UseNpgsql(appConfig.ConnectionStrings.DefaultConnection));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}
