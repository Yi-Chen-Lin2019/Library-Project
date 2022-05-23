using System.Reflection;
using API.Utilities;
using Application;
using Application.Contracts.Persistence;
using AutoMapper;
using DAL;
using DAL.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            //todo uncomment following after infrastructure is ready
            //services.AddScoped<ILibUserRepository, LibUserRepository>();
            //services.AddScoped<IBorrowOrderRepository, BorrowOrderRepository>();
            services.AddScoped<IItemDescriptorRepository, ItemDescriptorRepository>();
            services.AddScoped<DataContext, DataContext>();
            //services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            //services.AddAutoMapper(typeof(Profile));

            //services.AddMediatR(typeof(Startup));

            services.AddScoped<IDispatcher, Dispatcher>();
            services.AddApplicationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<ExceptionHandler>(); //Handling all exceptions here
        }
    }
}
