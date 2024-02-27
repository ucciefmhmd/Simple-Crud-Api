using DO1.Interface;
using DO1.Models.Database;
using DO1.Repository;
using Microsoft.EntityFrameworkCore;

namespace DO1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Connection String
            builder.Services.AddDbContext<DO1Context>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("con")));

            // Injection 
            builder.Services.AddScoped<IStudentRep, StudentRep>();
            builder.Services.AddScoped<IDepartmentRep, DepartmentRep>();


            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("Allownce", crosPolicy =>
                {
                    crosPolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

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

            app.UseAuthorization();

            app.UseCors("Allownce");

            app.MapControllers();

            app.Run();
        }
    }
}
