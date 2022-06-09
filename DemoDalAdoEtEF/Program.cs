using Dal.AdoService;
using Dal.Contexts;
using Dal.EfService;
using Dal.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Tools.Connections;

namespace DemoDalAdoEtEF
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

            builder.Services.AddSingleton(sp => new Connection(SqlClientFactory.Instance, builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<IContactRepository, AdoContactService>();

            //builder.Services.AddDbContext<ContactDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            //builder.Services.AddScoped<IContactRepository, EfContactService>();


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