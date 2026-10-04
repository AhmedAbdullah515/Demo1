
using Demo1.App_Context;
using Demo1.Mapping;
using Demo1.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Demo1
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
            builder.Services.AddDbContext<AppDBContext>(a => a.UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUitOfWork, UnitWork>();
            builder.Services.AddAutoMapper(a => a.AddProfile<MappingProfile>());
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
