
using ECommerceApi.Bussiness.Abstract;
using ECommerceApi.Bussiness.Concrete;
using ECommerceApi.Contexts;
using ECommerceApi.DataAccess.Abstract;
using ECommerceApi.DataAccess.EF;
using ECommerceApi.DataAccess.Repositories;
using ECommerceApi.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace ECommerceApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // CORS Policy:

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(name: "Test",policy =>
                {
                    policy.WithOrigins("*") // izin verilen kaynaklarýn listesi. þu anda cors devre dýþý
                    .AllowAnyHeader()
                    .AllowAnyMethod(); 
                });
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            ServiceExtension.AddServiceExtension(builder.Services); // Servislerin Tanýmlanmasý

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Mapper Tanýmlama


            ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();

            var app = builder.Build();

            app.UseCors("Test"); // Cors

            var context = serviceProvider.GetRequiredService<EDbContext>();

            Console.WriteLine(context.Database.EnsureCreated() ? "Database Created" : "Database Available"); // Db nin oluþturulmasý


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
