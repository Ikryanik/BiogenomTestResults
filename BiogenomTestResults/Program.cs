using BiogenomTestResults.DbContext;
using BiogenomTestResults.Repositories;
using BiogenomTestResults.Services;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTestResults
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var appConfig = new AppConfig(builder);
            builder.Services.AddSingleton(appConfig);

            // Add services to the container.
            builder.Services.AddScoped<NecessaryFoodSupplementRepository>();
            builder.Services.AddScoped<HealthIndicatorService>();
            builder.Services.AddScoped<HealthIndicatorResultsRepository>();
            builder.Services.AddScoped<FoodSupplementsService>();

            builder.Services.AddControllers();
            builder.Services.AddDbContext<BopgenomdbContext>(options =>
                options.UseNpgsql(appConfig.ConnectionStrings.DefaultConnection));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
