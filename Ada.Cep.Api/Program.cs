using Ada.Cep.Service;
using Ada.Cep.Service.ApiClient;
using Ada.Cep.Service.Cache;

namespace Ada.Cep.Api
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

            builder.Services.AddTransient<ICepApiClient, CepApiClient>();
            builder.Services.AddTransient<ICepCacheService, CepCacheService>();
            builder.Services.AddTransient<ICepService, CepService>();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = Constants.Cep.CepApiBaseUrl
            });

            var app = builder.Build();

            //var builder = WebApplication.CreateBuilder(args);
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