using Application;
using Application.Contracts.Persistence;
using AutoMapper;
using DAL;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Library.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Centisoft.API", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddScoped(typeof(ILibUserRepository), typeof(LibUserRepository));
            services.AddScoped<ILibUserRepository, LibUserRepository>();

            services.AddScoped(typeof(IBorrowOrderRepository), typeof(BorrowOrderRepository));
            services.AddScoped<IBorrowOrderRepository, BorrowOrderRepository>();

            services.AddScoped(typeof(IItemDescriptorRepository), typeof(ItemDescriptorRepository));
            services.AddScoped<IItemDescriptorRepository, ItemDescriptorRepository>();

            services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
            services.AddScoped<IReservationRepository, ReservationRepository>();

            services.AddScoped<IDispatcher, Dispatcher>();
            services.AddScoped<DataContext, DataContext>();

            services.AddAutoMapper(typeof(Profile));

            services.AddMediatR(typeof(Startup).Assembly);

            services.AddApplicationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("Open");

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
        }
    }
}
